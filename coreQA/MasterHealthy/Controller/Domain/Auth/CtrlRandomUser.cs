using Master.Controller.Infra;
using Master.Controller.Manager;
using Master.Entity;
using Master.Entity.Dto.Domain.Auth;
using Master.Service.Domain.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Master.Controller.Domain.Auth
{
    public class HealthyData
    {
        public List<HealthyBeneficiario> beneficiarios = new List<HealthyBeneficiario> { };
        public List<HealthyProdutos> produtos = new List<HealthyProdutos> { };
        public string Cartao { get; set; }
        public string CPF { get; set; }

        public HealthyData()
        {
            produtos = new List<HealthyProdutos>
            {
                new HealthyProdutos { EAN = "7891142203410" },
                new HealthyProdutos { EAN = "7898569766634" },
                new HealthyProdutos { EAN = "7896714290478" },
                new HealthyProdutos { EAN = "7896006219095" },
                new HealthyProdutos { EAN = "7896112169321" },
                new HealthyProdutos { EAN = "7896004743677" },
                new HealthyProdutos { EAN = "7891317118228" },
                new HealthyProdutos { EAN = "7898040326128" },
                new HealthyProdutos { EAN = "7891317020392" },
                new HealthyProdutos { EAN = "7896004763118" },
                new HealthyProdutos { EAN = "7896181914235" },
                new HealthyProdutos { EAN = "7896004731742" },
                new HealthyProdutos { EAN = "7896641804106" },
                new HealthyProdutos { EAN = "7896658038327" },
                new HealthyProdutos { EAN = "7891317137359" },
                new HealthyProdutos { EAN = "7898216372256" },
            };

            beneficiarios.AddRange(new HealthyBeneficiario[]
            {
                new HealthyBeneficiario { VirtualCardNumber = "63957313023370311", SocialNumber = "67192391395" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313020193911", SocialNumber = "10400601532" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313022064011", SocialNumber = "12303037077" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313020041011", SocialNumber = "72089627743" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313024195711", SocialNumber = "00794186947" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313020703611", SocialNumber = "19556187987" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313021340111", SocialNumber = "61273457072" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313021333211", SocialNumber = "54524673431" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313019757211", SocialNumber = "60538922460" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313023313711", SocialNumber = "62533523348" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313022245011", SocialNumber = "60745339620" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313021801111", SocialNumber = "84712343869" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313022221311", SocialNumber = "01629083690" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313022938911", SocialNumber = "74145656539" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313020611211", SocialNumber = "37902634514" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313022747911", SocialNumber = "25817856328" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313024261311", SocialNumber = "49456990036" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313021045411", SocialNumber = "23059113866" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313024362311", SocialNumber = "33130481613" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313021737911", SocialNumber = "31686897006" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313023079711", SocialNumber = "76835126809" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313019543411", SocialNumber = "51533556164" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313021021211", SocialNumber = "28290650183" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313021078411", SocialNumber = "45144864503" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313023988711", SocialNumber = "72418953807" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313023887811", SocialNumber = "75512244086" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313021741811", SocialNumber = "68535253297" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313021556011", SocialNumber = "29952947810" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313021578511", SocialNumber = "28769610401" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313021720411", SocialNumber = "31817921959" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313020800111", SocialNumber = "57455137486" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313022655011", SocialNumber = "74273131862" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313023321211", SocialNumber = "78157071305" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313022115911", SocialNumber = "10635617951" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313020502511", SocialNumber = "69683767761" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313022826011", SocialNumber = "50129460737" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313022617111", SocialNumber = "66371780042" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313021497611", SocialNumber = "55230754001" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313023280011", SocialNumber = "47288738701" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313020654811", SocialNumber = "79555445605" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313019977911", SocialNumber = "08198479767" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313020199611", SocialNumber = "20196047285" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313021568411", SocialNumber = "08488836597" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313020160111", SocialNumber = "66896023899" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313022803611", SocialNumber = "06559034372" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313024183111", SocialNumber = "81020103396" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313023552411", SocialNumber = "00844034207" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313023657111", SocialNumber = "95457714454" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313023302411", SocialNumber = "50955016940" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313022189411", SocialNumber = "48438760201" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313022742011", SocialNumber = "44522297009" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313024303011", SocialNumber = "32420249909" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313024304611", SocialNumber = "80928918696" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313021612911", SocialNumber = "00185038298" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313019951211", SocialNumber = "25806426092" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313021587711", SocialNumber = "58446579936" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313021387811", SocialNumber = "29866699803" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313019997211", SocialNumber = "24640071531" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313023712011", SocialNumber = "33465632354" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313021653111", SocialNumber = "95706538174" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313019495611", SocialNumber = "18961161911" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313022668111", SocialNumber = "25368648472" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313019649311", SocialNumber = "49619834038" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313021260811", SocialNumber = "33337161782" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313020784411", SocialNumber = "88610387941" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313021653711", SocialNumber = "67563704728" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313022760711", SocialNumber = "95465044322" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313023384411", SocialNumber = "11320836992" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313024038311", SocialNumber = "80089434595" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313022392411", SocialNumber = "32690628694" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313020323011", SocialNumber = "80114024472" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313022542111", SocialNumber = "52311267647" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313022726211", SocialNumber = "22751528813" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313019653711", SocialNumber = "58963627144" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313021338711", SocialNumber = "75298948111" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313022381411", SocialNumber = "17991437833" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313019427811", SocialNumber = "23320264958" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313023040011", SocialNumber = "33499258200" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313021859511", SocialNumber = "93137414741" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313022082311", SocialNumber = "62844134084" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313022603511", SocialNumber = "12029803766" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313020708011", SocialNumber = "45072347435" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313021978211", SocialNumber = "11681821826" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313019986411", SocialNumber = "18681519484" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313023633611", SocialNumber = "78347626219" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313024224111", SocialNumber = "40449409406" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313021858611", SocialNumber = "39074577300" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313022080711", SocialNumber = "46760556097" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313023619111", SocialNumber = "37310770943" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313021013711", SocialNumber = "34613869528" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313019785211", SocialNumber = "17044282202" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313022793911", SocialNumber = "94299012658" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313021575011", SocialNumber = "11827842679" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313022016211", SocialNumber = "48309974604" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313023690111", SocialNumber = "96311505690" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313023580511", SocialNumber = "54138727477" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313023930511", SocialNumber = "83286162701" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313022441511", SocialNumber = "16033410807" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313021884311", SocialNumber = "81688405186" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313022035811", SocialNumber = "91146034709" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313019883611", SocialNumber = "20864536208" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313024103411", SocialNumber = "68542847911" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313022631911", SocialNumber = "24801578497" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313022644711", SocialNumber = "51412263441" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313023045911", SocialNumber = "18014896106" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313023332411", SocialNumber = "72215675730" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313021886511", SocialNumber = "83664532600" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313022749211", SocialNumber = "16483443056" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313022371911", SocialNumber = "57226573873" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313023135911", SocialNumber = "57718026892" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313019495911", SocialNumber = "68619016520" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313021256711", SocialNumber = "07608443561" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313022919511", SocialNumber = "61776098307" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313023526511", SocialNumber = "03500277225" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313019775211", SocialNumber = "39094848406" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313023743611", SocialNumber = "68207880023" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313021774311", SocialNumber = "94250011623" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313021040511", SocialNumber = "17138141610" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313023801611", SocialNumber = "56605633849" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313024277611", SocialNumber = "79841800403" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313023432711", SocialNumber = "50248292048" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313019654111", SocialNumber = "90415843901" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313019929111", SocialNumber = "23051000353" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313020458111", SocialNumber = "44010705000" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313020875711", SocialNumber = "78923279080" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313020958011", SocialNumber = "30173285899" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313020672711", SocialNumber = "98216283709" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313021757211", SocialNumber = "03485830100" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313023062711", SocialNumber = "20472680609" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313020903211", SocialNumber = "31538090970" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313020664611", SocialNumber = "86589745536" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313020806011", SocialNumber = "52102087107" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313022459611", SocialNumber = "21519572174" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313019898511", SocialNumber = "47020994504" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313019813811", SocialNumber = "96589277699" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313022003611", SocialNumber = "38376290908" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313019816111", SocialNumber = "45580983832" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313020687211", SocialNumber = "06821605394" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313020261611", SocialNumber = "22418960986" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313021778311", SocialNumber = "80073792152" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313019710611", SocialNumber = "69080622958" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313024050811", SocialNumber = "33729957678" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313020355411", SocialNumber = "30857694472" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313021451211", SocialNumber = "07934504462" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313021191011", SocialNumber = "45835637608" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313020804911", SocialNumber = "27291801419" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313021073111", SocialNumber = "92542683484" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313021647711", SocialNumber = "42177829267" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313022766611", SocialNumber = "86444997771" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313021886811", SocialNumber = "84695671875" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313020187811", SocialNumber = "57569809203" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313021817111", SocialNumber = "80416933777" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313022259111", SocialNumber = "86314560632" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313023247511", SocialNumber = "52913957960" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313021529611", SocialNumber = "26823466855" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313024085811", SocialNumber = "80397473923" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313022800911", SocialNumber = "95108574169" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313023643911", SocialNumber = "72796005810" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313019608211", SocialNumber = "93867818169" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313020042311", SocialNumber = "81435512294" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313020857111", SocialNumber = "85422335570" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313021392011", SocialNumber = "49764180736" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313021847211", SocialNumber = "72633238939" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313023981911", SocialNumber = "23585451713" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313022582711", SocialNumber = "38647996941" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313019440811", SocialNumber = "03767169592" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313022275511", SocialNumber = "47941943662" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313023781011", SocialNumber = "27456316406" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313021195711", SocialNumber = "92390579787" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313021581711", SocialNumber = "60503348627" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313023309611", SocialNumber = "91014648335" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313024337811", SocialNumber = "01635829399" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313022575011", SocialNumber = "77279887902" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313023386511", SocialNumber = "28894232123" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313022000911", SocialNumber = "86879726798" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313024251711", SocialNumber = "42690371642" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313021360311", SocialNumber = "43755041960" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313021134111", SocialNumber = "42167787553" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313019436411", SocialNumber = "45291263237" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313020835811", SocialNumber = "86264158429" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313020637811", SocialNumber = "99248240089" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313023217311", SocialNumber = "67066242920" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313023327011", SocialNumber = "40762095911" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313020988411", SocialNumber = "44946671889" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313022056011", SocialNumber = "90820461725" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313023388011", SocialNumber = "20734814933" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313020086511", SocialNumber = "48838279179" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313020374511", SocialNumber = "96024638132" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313019581311", SocialNumber = "81597656062" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313022310411", SocialNumber = "07504805211" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313022001411", SocialNumber = "54026295109" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313023045711", SocialNumber = "83810096938" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313022618211", SocialNumber = "94998108034" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313020754911", SocialNumber = "91547619058" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313024024611", SocialNumber = "16895199080" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313022252211", SocialNumber = "64180907720" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313022440411", SocialNumber = "11546488774" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313023577711", SocialNumber = "41595099670" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313021727711", SocialNumber = "69803871706" },
                new HealthyBeneficiario { VirtualCardNumber = "63957313021633511", SocialNumber = "20085786586" },

            });;
        }
    }

    public class HealthyBeneficiario
    {
        public string VirtualCardNumber { get; set; }
        public string SocialNumber { get; set; }
    }

    public class HealthyProdutos
    {
        public string EAN { get; set; }
    }

    public class CtrlRandomUser : MasterController
    {
        public CtrlRandomUser(IOptions<LocalNetwork> network, IMemoryCache cache, IAppManager appManager) : base(network, cache, appManager) { }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/randomUser")]
        public async Task<ActionResult> RandomUser()
        {
            var data = new HealthyData();

            var max = data.beneficiarios.Count;
            var id = GenerateRandomNumber(data.beneficiarios.Count);
            var id_prod = GenerateRandomNumber(data.produtos.Count);

            var tag = string.Empty;

            var IsUsed = true;

            for (int t = 0; t < max; t++)
            {
                tag = "Random_" + id + "_";

                IsUsed = IsProcessCached<DtoRandomUser>(tag);

                if (!IsUsed)
                    break;

                id = GenerateRandomNumber(max);
            }

            if (IsUsed)
            {
                AppManager.RemoveAllCache(MemoryCache, string.Empty, new List<string> { "Random_" });

                tag = "Random_" + id + "_";

                IsProcessCached<DtoRandomUser>(tag);
            }

            var srv = RegisterService<SrvRandomUser>();

            if (!srv.Exec(id, id_prod, data, Network))
            {
                return BadRequest(srv.Error);
            }

            return Ok(SaveProcessCache(tag, srv.OutDto));
        }
    }
}
