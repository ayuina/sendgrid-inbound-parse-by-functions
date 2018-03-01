using System.Net;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Info("--- Headers ---");
    foreach(var h in req.Headers)
    {
        string values = h.Value.Aggregate((x,y) => $"{x}; {y}"); 
        log.Info($"{h.Key}: {values}");
    }
    log.Info(Environment.NewLine);

    MultipartMemoryStreamProvider provider = await req.Content.ReadAsMultipartAsync();
    int idx = 0;
    foreach(HttpContent part in provider.Contents)
    {
        log.Info($"--- MultiPart Content [{part.Headers.ContentDisposition.Name}] ---");
        foreach(var h in part.Headers)
        {
            string values = h.Value.Aggregate((x,y) => $"{x}; {y}"); 
            log.Info($"{h.Key}: {values}");
        }
        log.Info(Environment.NewLine);
        var body = await part.ReadAsStringAsync();
        log.Info(body);
    }
    
    return req.CreateResponse(HttpStatusCode.OK, "Received");
}
