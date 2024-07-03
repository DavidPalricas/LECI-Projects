# 1st-project-group_29
1st-project-group_29 created by GitHub Classroom

### Description

In the context of the Information Security in Organizations discipline, we have completed the second project: "Assignment 2: Application Security Verification Standard (ASVS)," which is based on the implementation of level 1 requirements of the Application Security Verification Standard (ASVS) on our website, as well as some critical features for its security.

### How to Run:
- app_org:
    - First Step-> You need to install the following python module: 
		- Cherrypy
    	- Sqlite3

    - Second Step -> Write python3 app.py in your terminal

    - Third Step-> Click on the address shown in the terminal
- app_sec:
    - First Step-> You need to install the following python modules: 
		- Pillow
		- Pyotp
		- Cherrypy
    	- Requests
      	- Qrcode
        - Secrets 
		
    - Second Step -> Write python3 app.py in your terminal

    - Third Step-> Click on the address shown in the terminal


### Issues fixed:
- Verify that cookie-based session tokens have the ’Secure’ attribute set. (CWE 614, NIST: 7.1.1 #3.4.1)

- Verify that cookie-based session tokens have the ’HttpOnly’ attribute set. (CWE 1004, NIST: 7.1.1 #3.4.2)

- Verify that cookie-based session tokens utilize the ’SameSite’ attribute to limit exposure to cross-site request forgery attacks. (CWE 16, NIST: 7.1.1 #3.4.3)

- Verify that passwords submitted during account registration, login, and password change are checked against a set of breached passwords either locally (such as the top 1,000 or 10,000 most common passwords which match the system’s password policy) or using an external API. If using an API a zero knowledge proof or other mechanism should be used to ensure that the plain text password is not sent or used in verifying the breach status of the password. If the password is breached, the application must require the user to set a new non-breached password. (CWE 521, #2.1.8)

- Verify that time-based OTPs have a defined lifetime before expiring. (CWE 613, #2.8.1)

- Verify system generated initial passwords or activation codes SHOULD be securely randomly generated, SHOULD be at least 6 characters long, and MAY contain letters and numbers, and expire after a short period of time. These initial secrets must not be permitted to become the long term password. (CWE 330, #2.3.1)

- Verify that the user can choose to either temporarily view the entire masked password, or temporarily view the last typed character of the password on platforms that do not have this as built-in functionality. (CWE 521, #2.1.12)

- Verify that a password strength meter is provided to help users set a stronger password (o CWE 521, NIST: 5.1.1.2 #2.1.8)

- Verify that passwords 64 characters or longer are permitted but may be no longer than 128 characters.  (CWE 521, NIST: 5.1.1.2. #2.1.2)

- Verify that user set passwords are at least 12 characters in length (after multiple spaces are combined). (CWE 521, NIST: 5.1.1.2. #2.1.1)


### Software Features Implemented:
- Multi-factor Authentication (MFA):
    - Click in this link to see our youtube video to understand our MFA implementation, you can also found this video in the folder "analysis":
        - https://www.youtube.com/watch?v=CLMhtTPbPVA

- Password strength evaluation


### IMPORTANT:
- For more information read the report (PDF file) which can be found in the folder "analysis" with the name "Segurança_Informática_e_nas_Organizações___Projeto_2"
  ### Authors
  - David Palricas - 108780
  - Eduardo Alves - 104179
  - Inês Silva - 104332
  - João Alcatrão - 76763
  - Mariana Silva - 98392

