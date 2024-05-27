using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
public class HYPLAYLogin : MonoBehaviour
{
    // Replace with your HYPLAY app information
    private string hyplayClientId = "18a66edf-b14c-4831-a04a-1194b35b9133";
    private string hyplayClientSecret = "app_sk_zaYysUDzbUkf4qp8UFT8loainysqmM9CcDVftsrhCDAKdsYgtkc89wYZcl71TKgd";
    private string hyplayRedirectUri = "http://localhost:3000/callback"; // Update if your redirect URI is different

    // URL of the HYPLAY SSO endpoint (should not be changed)
    private string hyplaySSOEndpoint = "https://sso.hyplay.com/auth/realms/YOUR_REALM/protocol/openid-connect/token";

    // Text fields and button (assuming you have them in your scene)
    public TMP_InputField usernameField;
    public TMP_InputField passwordField;
    public Button loginButton;

    // Text for showing the login status
    public TextMeshProUGUI statusText;

    void Start()
    {
        // Initialize the login button
        loginButton.onClick.AddListener(OnLoginButtonClick);
    }

    void OnLoginButtonClick()
    {
        // Get username and password (assuming validation is done elsewhere)
        string username = usernameField.text;
        string password = passwordField.text;

        // Generate the HYPLAY authorization URL
        string authorizationUrl = string.Format("https://sso.hyplay.com/auth/realms/{0}/protocol/openid-connect/authorize?response_type=code&client_id={1}&redirect_uri={2}&scope=openid+profile&state=12345&username={3}&password={4}",
            "YOUR_REALM", // Replace with your HYPLAY realm name
            hyplayClientId,
            hyplayRedirectUri,
            username,
            password);

        // Open the authorization URL in a web browser
        Application.OpenURL(authorizationUrl);
    }

    // Handle the response from HYPLAY after authentication
    public void HandleHYPLAYResponse(string code)
    {
        // Exchange the authorization code for an access token
        StartCoroutine(ExchangeAuthorizationCodeForAccessToken(code));
    }

    IEnumerator ExchangeAuthorizationCodeForAccessToken(string code)
    {
        // Create a POST request to the HYPLAY SSO endpoint
        WWWForm form = new WWWForm();
        form.AddField("grant_type", "authorization_code");
        form.AddField("code", code);
        form.AddField("client_id", hyplayClientId);
        form.AddField("client_secret", hyplayClientSecret);
        form.AddField("redirect_uri", hyplayRedirectUri);

        WWW request = new WWW(hyplaySSOEndpoint, form);
        yield return request;

        // Process the response
        if (request.isDone)
        {
            if (request.error == null)
            {
                // Parse the JSON response
                string responseJson = request.text;
                Dictionary<string, object> response = JsonUtility.FromJson<Dictionary<string, object>>(responseJson);

                // Get the access token
                string accessToken = (string)response["access_token"];

                // Store the access token (e.g., PlayerPrefs)
                PlayerPrefs.SetString("hyplay_access_token", accessToken);

                // Update the login status
                statusText.text = "Login exitoso!";
            }
            else
            {
                // Show an error message
                statusText.text = "Error: " + request.error;
            }
        }
        else
        {
            // Show an error message
            statusText.text = "Error: No se pudo conectar a HYPLAY.";
        }
    }
}
