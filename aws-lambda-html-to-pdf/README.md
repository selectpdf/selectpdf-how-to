# HTML to PDF in AWS Lambda with C# (x86_64 and arm64)

Generate PDFs from HTML in an AWS Lambda function in C#, packaged as a container image on x86_64 or arm64 Graviton, with the Dockerfile and deployment steps.

**Step-by-step guide:** https://selectpdf.com/how-to/aws-lambda-html-to-pdf/

## Run it

```bash
docker build --platform linux/amd64 --provenance=false --sbom=false -t pdf-lambda .
docker run -p 9000:8080 pdf-lambda

# in a second terminal: send an event to the emulator in the image, decode the PDF
curl -s http://localhost:9000/2015-03-31/functions/function/invocations \
     -d '{"body":"<h1>Account statement</h1>"}' | jq -r .body | base64 -d > statement.pdf
```

The request returns `statement.pdf`. Requires the .NET 10 SDK. Deployment steps: https://selectpdf.com/how-to/aws-lambda-html-to-pdf/#deploy

## License key

Without a key, every page carries a trial watermark. Set `SELECTPDF_LICENSE_KEY` to your key, or assign `SelectPdf.Universal.GlobalProperties.LicenseKey` before the first conversion. [Free trial](https://selectpdf.com/downloads/) · [Pricing](https://selectpdf.com/pricing/)

## Documentation

- [Deployment to AWS Lambda](https://selectpdf.com/pdf-library/html/AWS-Lambda.htm)
- [Amazon Web Services](https://selectpdf.com/pdf-library/html/Amazon-Web-Services.htm)
- [Deployment with Docker](https://selectpdf.com/pdf-library/html/Deployment-Docker.htm)
