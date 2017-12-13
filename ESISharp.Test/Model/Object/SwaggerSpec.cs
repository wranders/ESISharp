using Newtonsoft.Json;
using System.Collections.Generic;

namespace ESISharp.Test.Framework.Object
{
    public class SwaggerSpec
    {
        [JsonProperty(PropertyName = "swagger")]
        public string Swagger { get; set; }

        [JsonProperty(PropertyName = "info")]
        public Dictionary<string, string> Info { get; set; }

        [JsonProperty(PropertyName = "host")]
        public string Host { get; set; }

        [JsonProperty(PropertyName = "basePath")]
        public string BasePath { get; set; }

        [JsonProperty(PropertyName = "schemes")]
        public IEnumerable<string> Schemes { get; set; }

        [JsonProperty(PropertyName = "produces")]
        public IEnumerable<string> Produces { get; set; }

        [JsonProperty(PropertyName = "paths")]
        public Dictionary<string, Dictionary<string, SwaggerMethodInfo>> Paths { get; set; }

        [JsonProperty(PropertyName = "securityDefinitions")]
        public SwaggerSecurityDefinitions SecurityDefinitions { get; set; }

        [JsonProperty(PropertyName = "parameters")]
        public Dictionary<string, SwaggerParametersInfo> Parameters { get; set; }

        [JsonProperty(PropertyName = "definitions")]
        public Dictionary<string, SwaggerDefinitionInfo> Definitions { get; set; }

        public class SwaggerMethodInfo
        {
            [JsonProperty(PropertyName = "description")]
            public string Description { get; set; }

            [JsonProperty(PropertyName = "summary")]
            public string Summary { get; set; }

            [JsonProperty(PropertyName = "tags")]
            public IEnumerable<string> Tags { get; set; }

            [JsonProperty(PropertyName = "parameters")]
            public IEnumerable<SwaggerParameterInfo> Parameters { get; set; }

            [JsonProperty(PropertyName = "responses")]
            public Dictionary<string, SwaggerResponseInfo> Responses { get; set; }

            [JsonProperty(PropertyName = "operationId")]
            public string OperationId { get; set; }

            [JsonProperty(PropertyName = "x-cached-seconds")]
            public string XCachedSeconds { get; set; }

            [JsonProperty(PropertyName = "x-alternative-versions")]
            public IEnumerable<string> XAlternateVersions { get; set; }

            public class SwaggerParameterInfo
            {
                [JsonProperty(PropertyName = "$ref")]
                public string Ref { get; set; }
            }

            public class SwaggerResponseInfo
            {
                [JsonProperty(PropertyName = "description")]
                public string Description { get; set; }

                [JsonProperty(PropertyName = "schema")]
                public SwaggerSchemaInfo Schema { get; set; }

                [JsonProperty(PropertyName = "headers")]
                public Dictionary<string, SwaggerHeaderInfo> Headers { get; set; }

                public class SwaggerSchemaInfo
                {
                    [JsonProperty(PropertyName = "type")]
                    public string Type { get; set; }

                    [JsonProperty(PropertyName = "required")]
                    public IEnumerable<string> Required { get; set; }

                    [JsonProperty(PropertyName = "properties")]
                    public Dictionary<string, SwaggerPropertyInfo> Properties { get; set; }

                    [JsonProperty(PropertyName = "title")]
                    public string Title { get; set; }

                    [JsonProperty(PropertyName = "description")]
                    public string Description { get; set; }

                    public class SwaggerPropertyInfo
                    {
                        [JsonProperty(PropertyName = "type")]
                        public string Type { get; set; }

                        [JsonProperty(PropertyName = "description")]
                        public string Description { get; set; }

                        [JsonProperty(PropertyName = "title")]
                        public string Title { get; set; }

                        [JsonProperty(PropertyName = "format")]
                        public string Format { get; set; }
                    }
                }

                public class SwaggerHeaderInfo
                {
                    [JsonProperty(PropertyName = "description")]
                    public string Description { get; set; }

                    [JsonProperty(PropertyName = "type")]
                    public string Type { get; set; }
                }
            }
        }

        public class SwaggerSecurityDefinitions
        {
            [JsonProperty(PropertyName = "evesso")]
            public SwaggerEveSso EveSso { get; set; }

            public class SwaggerEveSso
            {
                [JsonProperty(PropertyName = "type")]
                public string Type { get; set; }

                [JsonProperty(PropertyName = "authorizationUrl")]
                public string AuthorizationUrl { get; set; }

                [JsonProperty(PropertyName = "flow")]
                public string Flow { get; set; }

                [JsonProperty(PropertyName = "scopes")]
                public Dictionary<string, string> Scopes { get; set; }
            }
        }

        public class SwaggerParametersInfo
        {
            [JsonProperty(PropertyName = "datasource")]
            public SwaggerParameter Datasource { get; set; }

            [JsonProperty(PropertyName = "user_agent")]
            public SwaggerParameter UserAgent { get; set; }

            [JsonProperty(PropertyName = "X-User-Agent")]
            public SwaggerParameter XUserAgent { get; set; }

            [JsonProperty(PropertyName = "token")]
            public SwaggerParameter Token { get; set; }

            [JsonProperty(PropertyName = "character_id")]
            public SwaggerParameter CharacterID { get; set; }

            [JsonProperty(PropertyName = "corporation_id")]
            public SwaggerParameter CorporationID { get; set; }

            [JsonProperty(PropertyName = "page")]
            public SwaggerParameter Page { get; set; }

            [JsonProperty(PropertyName = "language")]
            public SwaggerParameter Language { get; set; }

            [JsonProperty(PropertyName = "alliance_id")]
            public SwaggerParameter AllianceID { get; set; }

            public class SwaggerParameter
            {
                [JsonProperty(PropertyName = "name")]
                public string Name { get; set; }

                [JsonProperty(PropertyName = "description")]
                public string Description { get; set; }

                [JsonProperty(PropertyName = "format")]
                public string Format { get; set; }

                [JsonProperty(PropertyName = "in")]
                public string In { get; set; }

                [JsonProperty(PropertyName = "required")]
                public bool Required { get; set; }

                [JsonProperty(PropertyName = "type")]
                public string Type { get; set; }

                [JsonProperty(PropertyName = "default")]
                public dynamic Default { get; set; }

                [JsonProperty(PropertyName = "enum")]
                public IEnumerable<string> Enum { get; set; }
            }
        }

        public class SwaggerDefinitionInfo
        {
            [JsonProperty(PropertyName = "type")]
            public string Type { get; set; }

            [JsonProperty(PropertyName = "description")]
            public string Description { get; set; }

            [JsonProperty(PropertyName = "title")]
            public string Title { get; set; }

            [JsonProperty(PropertyName = "required")]
            public IEnumerable<string> Required { get; set; }

            [JsonProperty(PropertyName = "properties")]
            public Dictionary<string, SwaggerPropertyInfo> Properties { get; set; }

            public class SwaggerPropertyInfo
            {
                [JsonProperty(PropertyName = "type")]
                public string Type { get; set; }

                [JsonProperty(PropertyName = "description")]
                public string Description { get; set; }
            }
        }
    }
}