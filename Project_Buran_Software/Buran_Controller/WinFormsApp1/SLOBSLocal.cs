using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SLOBSharp;
using SLOBSharp.Client.Requests;
using SLOBSharp.Client.Requests.Scenes;
using SLOBSharp.Client.Responses;
using SLOBSharp.Client;
using SLOBSharp.Domain.Services;
using SLOBSharp.Domain;

namespace Buran
{
    public class SLOBSLocal
    {
        SlobsPipeClient pipeClient;

        public SLOBSLocal()
        {
            this.pipeClient = new SlobsPipeClient("slobs");
        }

        public void authRequest(string key)
        {
            issueRequest(SlobsRequestBuilder.NewRequest().SetMethod("auth").SetResource("TcpServerService").AddArgs(new string [] { key }).BuildRequest());
        }

        public List<String> getScenes()
        {
            List<SlobsResult> responses = issueRequest(SlobsRequestBuilder.NewRequest().SetMethod("getScenes").SetResource("ScenesService").BuildRequest()).Result.ToList();
            List<String> scenes = new List<string>();

            foreach(SlobsResult sr in responses)
            {
                scenes.Add(sr.Id);
            }

            return scenes;
        }

        public void switchToScene(string scene)
        {
            issueRequest(SlobsRequestBuilder.NewRequest().SetMethod("makeSceneActive").SetResource("ScenesService").AddArgs(new string[] { scene }).BuildRequest());
        }

        private SlobsRpcResponse issueRequest(ISlobsRequest request)
        {
            return this.pipeClient.ExecuteRequest(request);
        }
    }
}
