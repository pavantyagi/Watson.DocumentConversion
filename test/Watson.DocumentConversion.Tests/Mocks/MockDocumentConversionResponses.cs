namespace Watson.DocumentConversion.Tests.Mocks
{
    public class MockDocumentConversionResponses
    {
        public const string MockAnswersResponse =
            "{\"source_document_id\":\"\",\"timestamp\":\"2016-02-18T06:35:02.234Z\",\"media_type_detected\":\"text/html\",\"metadata\":[],\"answer_units\":[{\"id\":\"ce4d4674-129e-4159-ad5b-024d6c264839\",\"type\":\"h1\",\"parent_id\":\"\",\"title\":\"Sample Html\",\"direction\":\"ltr\",\"content\":[{\"media_type\":\"text/plain\",\"text\":\"Para 1 Para 2 Bullet 1 Bullet 2\"}]}]}";

        public const string MockHtmlResponse =
            "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>\n<html>\n<head>\n<meta content=\"text/html; charset=UTF-8\" http-equiv=\"Content-Type\"/>\n<style type=\"text/css\">/**/\n.b1{white-space-collapsing:preserve;}\n.b2{margin: 0.4923611in 0.9847222in 0.59097224in 0.9847222in;}\n.s1{font-weight:bold;}\n.p1{margin-top:0.16666667in;margin-bottom:0.041666668in;text-align:start;hyphenate:auto;keep-with-next.within-page:always;font-family:Calibri Light;font-size:16pt;}\n.p2{text-align:start;hyphenate:auto;font-family:Times New Roman;font-size:12pt;}\n/**/</style>\n<meta content=\"Cliona Browne\" name=\"author\"/>\n<meta content=\"2016-02-18\" name=\"publicationdate\"/>\n\n</head>\n<body class=\"b1 b2\">\n\n<h1>\nHello World\n</h1>\n<p class=\"p2\">\nPara 1\n</p>\n<p class=\"p2\">\nPara 2\n</p>\n\n</body>\n</html>";

        public const string MockTextResponse =
            "Sample Docx\n\nPara 1\n\nPara 2\n\nBullet1 \nBullet2";
    }
}