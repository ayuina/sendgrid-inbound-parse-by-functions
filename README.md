# Receiving multipart/form-data POST by Azure Functions 

This sample function code parse HTTP POST request that mime type is multipart/form-data and dump to log stream. This would be usefull for receiving webhook from SendGrid's inbound parse.

## How to use

1. Create Azure Functions app in your Azure account
2. Deploy this in wwwroot or sync with repo

## Description

When you want to parse HTTP request body encoded by multipart/form-data , you can get [MultipartMemoryStreamProvider](https://msdn.microsoft.com/ja-jp/library/system.net.http.multipartmemorystreamprovider(v=vs.118).aspx) object by calling ReadAsMultipartAsync() method, then you can enumerate Contents property and parse each part of POSTed body with [HttpContent](https://msdn.microsoft.com/ja-jp/library/system.net.http.httpcontent(v=vs.118).aspx) object.


If you want to specific part of email, query MultipartMemoryStreamProvider.Contents property by the name of ContentDisposition header

### Some output example
```
--- MultiPart Content ["from"] ---
Content-Disposition: form-data; name="from"

"user1@contoso.com" <user1@contoso.com>

--- MultiPart Content ["to"] ---
Content-Disposition: form-data; name="to"

"feedback@sample.com" <feedback@sample.com>

--- MultiPart Content ["html"] ---
Content-Disposition: form-data; name="html"

<html><body> Hello world !</body><html>

etc...
```


## References

[about SendGrid Inbound Parse Webhook](https://sendgrid.com/docs/Classroom/Basics/Inbound_Parse_Webhook/setting_up_the_inbound_parse_webhook.html)
