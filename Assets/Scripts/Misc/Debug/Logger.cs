#define DEBUG_MODE

using UnityEngine;
using UnityEngine.UI;

public class Logger : MonoBehaviour
{
	#region VARIABLES
	[SerializeField]
    private Text    textComponent;
    public  RectTransform   scrollviewContent;
    public  GameObject      scrollView;    
    public  Button  toggleButton;
    private Text    toggleBtnText;
	[SerializeField]
	private Button clearButton;
	[SerializeField]
	private GameObject dontDestroyObject;

	[SerializeField]
	private bool visibleOnInit;
	[SerializeField]
	private bool clampLogLines;
	[SerializeField]
	private int maxLines;

	private int linesCounter = 0;

	private System.Text.StringBuilder logString;

	const float ADDITIONAL_HEIGHT = 50f;
	#endregion

	private Text getTextComponent
    {
        get {
            if( textComponent == null )
            {
                textComponent = GetComponent<Text>();
            }
            return textComponent; }
    }

	private static Logger instance;

    void Awake( )
    {
		if( instance != null && instance != this )
		{
			Destroy( gameObject );
			return;
		}
		instance = this;
		if( dontDestroyObject != null )
		{
			DontDestroyOnLoad( dontDestroyObject );
		}
		logString = new System.Text.StringBuilder();
		clearButton.onClick.AddListener( Clear );
		toggleBtnText = toggleButton.GetComponentInChildren<Text>();
        toggleBtnText.text = scrollView.activeSelf ? "Hide Log" : "Show log";
        toggleButton.onClick.AddListener( ToggleLog );
		scrollView.SetActive( !visibleOnInit );
		ToggleLog();
        Application.logMessageReceived += HandleLog;
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        //Log( stackTrace+"\n"+logString );
        if(type == LogType.Error)
        Log(logString);
    }

    // Use this for initialization
    void Start( )
    {
    }

    private void OnDestroy( )
    {
        Application.logMessageReceived -= HandleLog;
    }

    public void ToggleLog( )
    {
        scrollView.SetActive( !scrollView.activeSelf );
        toggleBtnText.text = scrollView.activeSelf ? "Hide Log":"Show log";
    }

	public void Clear( )
	{
		getTextComponent.text = "";
		scrollviewContent.sizeDelta = new Vector2( getTextComponent.preferredWidth + ADDITIONAL_HEIGHT, getTextComponent.preferredHeight + ADDITIONAL_HEIGHT );
	}

    public static void Log(string text, bool logToUnityConsoleToo = true )
    {
        if( instance == null ) { return; }
#if DEBUG_MODE
		instance.linesCounter += CountNewLines( text );
		if( instance.clampLogLines && instance.linesCounter >= instance.maxLines )
		{
			int diff = instance.linesCounter - instance.maxLines;
			instance.linesCounter -= diff;
			string logText = instance.getTextComponent.text;
			for( int i = 0; i < diff; i++ )
			{
				for( int j = 0; j < logText.Length; j++ )
				{
					if( logText[ j ] == '\n' )
					{
						logText = logText.Remove( 0, j + 1 );
						break;
					}
				}
			}
			logText = "Removing " + diff + " lines, lines number is "+ instance.linesCounter+"\n"+ logText;
			instance.getTextComponent.text = logText;
		}
		instance.getTextComponent.text += text + "\n";
		instance.scrollviewContent.sizeDelta = new Vector2( instance.getTextComponent.preferredWidth + ADDITIONAL_HEIGHT, instance.getTextComponent.preferredHeight + ADDITIONAL_HEIGHT );
        if( logToUnityConsoleToo )
        {
            //Debug.Log( text );
        }
#endif
	}

	private static int CountNewLines( string s )
	{
		int len = s.Length;
		int c = 0;
		for( int i = 0; i < len; i++ )
		{
			if( s[ i ] == '\n' )
				c++;
		}
		return c + 1;
	}
}
