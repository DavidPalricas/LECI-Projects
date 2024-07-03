import io, pyotp, base64, qrcode, secrets




def generate_totp_secret():
    # Generate a random 160-bit (20-byte) key
    random_bytes = secrets.token_bytes(20)

    # Base32 encode the random key
    base32_encoded_secret = base64.b32encode(random_bytes).decode('utf-8')

    return base32_encoded_secret




def generate_totp(secret):
    totp = pyotp.TOTP(secret)
    return totp.now()




def generate_totp_qr_code(account_name, secret):
    # Create a TOTP object
    totp = pyotp.TOTP(secret)

    # Generate the TOTP URI for the QR code
    totp_uri = totp.provisioning_uri(name=account_name, issuer_name='LojaDoDeti')

    # Create a QR code for the TOTP URI
    qr = qrcode.QRCode(
        version=1,
        error_correction=qrcode.constants.ERROR_CORRECT_L,
        box_size=10,
        border=4,
    )
    qr.add_data(totp_uri)
    qr.make(fit=True)

    # Create an image from the QR code
    img = qr.make_image(fill_color="black", back_color="white")

    # Save the image to a file (optional)
    #img.save('totp_qr_code.png')

    # Display the QR code image (optional)
    #img.show()

    img_bytes = io.BytesIO()
    img.save(img_bytes, format='PNG')
    img_bytes = img_bytes.getvalue()

    return totp.now(), img_bytes





if __name__ == "__main__":
    # Replace 'YourAccountName' and 'YourSecretKey' with your desired values
    account_name = 'Loja do Deti'
    secret_key = 'dorbeliscaopeitoesquerdopico'


    code1 = generate_totp_qr_code(account_name, secret_key)[0]
    print("TOTP Code1:", code1)
