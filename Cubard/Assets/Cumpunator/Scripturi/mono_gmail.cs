using UnityEngine;
using System.Collections;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public class mono_gmail : MonoBehaviour {

	public GameObject browser, cam;
	Browser script;
	Text script2;

	public Material negru;
	public GameObject planBlack, scris;
	public GameObject pmic;

	void Start()
	{
		script = browser.GetComponent<Browser>();
		script2 = cam.GetComponent<Text>();
	}





	IEnumerator FadeOut()
	{
		planBlack.SetActive(true);
		pmic.SetActive(false);
		for(float f = 0; f<=1; f+=0.05f)
		{
			Color c = negru.color;
			c.a = f;
			negru.color = c;
			yield return new WaitForSeconds(0.01f);
		}
		
		Color d = negru.color;
		d.a = 1;
		negru.color = d;

		yield return new WaitForSeconds(1);

		scris.SetActive(true);

		yield return new WaitForSeconds(10);


		Application.LoadLevel("MeniuProf");
	}



	IEnumerator OnMouseDown ()
	{

		StartCoroutine(FadeOut());

		Application.CaptureScreenshot(Application.persistentDataPath + "/" + "Screenshot.png");

		yield return new WaitForSeconds(1);

		MailMessage mail = new MailMessage();
		
		mail.From = new MailAddress("cubardprobleme@gmail.com");
		mail.To.Add("cubardprobleme@gmail.com");
		mail.Subject = script2.TextNume;
		mail.Body = script2.info + script2.TextCerinta;

		for(int i = 0; i<script.nr; i++)
		{
			mail.Attachments.Add (new Attachment(script.imagini[i]));
		}

		mail.Attachments.Add (new Attachment(Application.persistentDataPath + "/" + "Screenshot.png"));

		SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
		smtpServer.Port = 587;
		smtpServer.Credentials = new System.Net.NetworkCredential("cubardprobleme@gmail.com", "cubard79") as ICredentialsByHost;
		smtpServer.EnableSsl = true;
		ServicePointManager.ServerCertificateValidationCallback = 
			delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) 
		{ return true; };
		smtpServer.Send(mail);
		Debug.Log("success");


		
	}
}