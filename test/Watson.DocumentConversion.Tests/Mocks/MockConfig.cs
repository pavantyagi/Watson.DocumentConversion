namespace Watson.DocumentConversion.Tests.Mocks
{
    public class MockConfig
    {
        public const string MockMsWordConfig =
            "{\"word\":{\"heading\":{\"fonts\":[{\"level\":1,\"min_size\":24},{\"level\":2,\"min_size\":18,\"max_size\":23,\"bold\":true},{\"level\":3,\"min_size\":14,\"max_size\":17,\"italic\":false},{\"level\":4,\"min_size\":12,\"max_size\":13,\"name\":\"Times New Roman\"}],\"styles\":[{\"level\":1,\"names\":[\"pullout heading\",\"pulloutheading\",\"heading\"]},{\"level\":2,\"names\":[\"subtitle\"]}]}}}";

        public const string MockPdfConfig =
            "{\"pdf\":{\"heading\":{\"fonts\":[{\"level\":1,\"min_size\":24},{\"level\":2,\"min_size\":18,\"max_size\":23,\"bold\":true},{\"level\":3,\"min_size\":14,\"max_size\":17,\"italic\":false},{\"level\":4,\"min_size\":12,\"max_size\":13,\"name\":\"Times New Roman\"}]}}}";

        public const string MockHtmlConfig =
            "{\"normalize_html\":{\"exclude_tags_completely\":[\"script\",\"sup\"],\"exclude_tags_keep_content\":[\"font\",\"em\",\"span\"],\"keep_content\":{\"xpaths\":[\"//body/div[@id='content']\"]},\"exclude_content\":{\"xpaths\":[\"//*[@id='footer']\",\"//*[@id='navigation']\"]},\"keep_tag_attributes\":[\"*\"]}}";

        public const string MockAnswerUnitConfig =
            "{\"answer_units\":{\"selector_tags\":[\"h1\",\"h2\",\"h3\",\"h4\",\"h5\",\"h6\"]}}";
    }
}