using Newtonsoft.Json;
using RestSharp;

namespace Rest
{
    #region - entities - 

    public class Main
    {
        public string VirtualCardNumber { get; set; }

        public string SocialNumber { get; set; }
    }

    public class Shopper
    {
        public string VirtualCardNumber { get; set; }
        public string SocialNumber { get; set; }
    }

    public class NetworkInfo
    {
        public string Name { get; set; }
        public string FiscalNumber { get; set; }
    }

    public class State
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string District { get; set; }
    }

    public class SalesOrderItem
    {
        public string EAN { get; set; }
        public int ProductQuantity { get; set; }
        public object MedicalPrescription { get; set; }
    }

    public class PreviewSalesOrder
    {
        public string Source { get; set; }
        public Shopper Shopper { get; set; }
        public NetworkInfo NetworkInfo { get; set; }
        public State State { get; set; }
        public List<SalesOrderItem> SalesOrderItems { get; set; }
    }

    public class UniqueSequentialNumber
    {
        public object Value { get; set; }
    }

    public class UniqueSequentialNumberCorrelated
    {
        public object Value { get; set; }
    }


    public class Card
    {
        public bool IsBlocked { get; set; }
        public bool IsCancelled { get; set; }
        public string CardNumber { get; set; }
    }

    public class Beneficiary
    {
        public SocialNumber SocialNumber { get; set; }
        public Card Card { get; set; }
        public string Name { get; set; }
        public bool IsHolder { get; set; }
    }

    public class SocialNumber
    {
        public string Value { get; set; }
    }

    public class Product
    {
        public string Name { get; set; }
        public string Ean { get; set; }
        public string Laboratory { get; set; }
        public string Presentation { get; set; }
        public string Substance { get; set; }
        public string Type { get; set; }
        public string SubType { get; set; }
    }

    public class Item
    {
        public Product Product { get; set; }
        public int ProductQuantity { get; set; }
        public int AuthorizedQuantity { get; set; }
        public bool HasMedicalPrescription { get; set; }
        public int PaymentMethod { get; set; }
        public string PaymentMethodDescription { get; set; }
        public double UnitGrossPrice { get; set; }
        public double GrossPrice { get; set; }
        public double Price { get; set; }
        public double UnitPrice { get; set; }
        public double MdmPrice { get; set; }
        public double Discount { get; set; }
        public double DiscountValue { get; set; }
        public double NetworkPrice { get; set; }
        public double SubsidyDiscount { get; set; }
        public double SubsidyValue { get; set; }
        public double CardValue { get; set; }
        public double CheckoutValue { get; set; }
        public double EmploymentPayrollValue { get; set; }
        public double BeneficiaryValue { get; set; }
        public List<object> ErrorCauses { get; set; }
        public object MedicalPrescription { get; set; }
        public int MedicalPrescriptionStatus { get; set; }
        public string MedicalPrescriptionStatusDescription { get; set; }
        public bool UsedNetworkPrice { get; set; }
        public bool UsedNetworkGrossPrice { get; set; }
        public bool UsedNetworkNetPrice { get; set; }
        public bool UsedAttendanceDiscount { get; set; }
        public bool CheckedNetworkPriceWithPreSales { get; set; }
        public bool CheckedQuantityWithPreSales { get; set; }
        public bool CheckedProductsWithPreSales { get; set; }
        public bool PreSalesPricingConsultEnabled { get; set; }
        public bool SalesPricingConsultEnabled { get; set; }
        public bool UsedBenefitProductConfigurationDiscount { get; set; }
        public bool UsedBenefitClusterDiscount { get; set; }
    }

    public class TaxCoupon
    {
        public object NetworkReceipt { get; set; }
        public object ConsumerReceipt { get; set; }
    }

    public class ResponseTimeRuleEngine
    {
        public string CancelExceededPreSalesOrderPhase { get; set; }
        public string LoadSalesOrderPhase { get; set; }
        public string SalesOrderValidationPhase { get; set; }
        public string SalesOrderItemsValidationPhase { get; set; }
        public string BeneficiaryValidationPhase { get; set; }
        public string CompanyBeneficiaryPhase { get; set; }
        public string SaleDateValidationPhase { get; set; }
        public string PurchasePermissionPhase { get; set; }
        public string CalculateProductPriceAndDiscountPhase { get; set; }
        public string CalculateBalanceAndLimitPhase { get; set; }
        public string ProcessExternalAuthorizerPhase { get; set; }
        public string GenerateUniqueSequentialNumberPhase { get; set; }
        public string GenerateFiscalCouponPhase { get; set; }
        public string CompleteSalesOrderPhase { get; set; }
    }

    public class PreviewSalesOrderResp
    {
        public string SalesOrderKey { get; set; }
        public UniqueSequentialNumber UniqueSequentialNumber { get; set; }
        public UniqueSequentialNumberCorrelated UniqueSequentialNumberCorrelated { get; set; }
        public Beneficiary Beneficiary { get; set; }
        public DateTime TransactionDate { get; set; }
        public string SalesAction { get; set; }
        public NetworkInfo NetworkInfo { get; set; }
        public List<Item> Items { get; set; }
        public object ErrorCauses { get; set; }
        public TaxCoupon TaxCoupon { get; set; }
        public double TotalDiscountValue { get; set; }
        public double TotalGrossPrice { get; set; }
        public double TotalPrice { get; set; }
        public double TotalSubsidyValue { get; set; }
        public double TotalEmploymentPayrollValue { get; set; }
        public double TotalCheckoutValue { get; set; }
        public double TotalCardValue { get; set; }
        public string Status { get; set; }
        public string Source { get; set; }
        public bool HasPendingMedicalPrescriptionScans { get; set; }
        public int SalesOrderMonitorStatus { get; set; }
        public string SalesOrderMonitorStatusDescription { get; set; }
        public bool UsedAttendanceDiscount { get; set; }
        public ResponseTimeRuleEngine ResponseTimeRuleEngine { get; set; }
    }

    public class TaxFiscalReceipt
    {
        public string TaxNumber { get; set; }
        public string TaxType { get; set; }
        public string AccessKey { get; set; }
    }

    public class SalesOrderItem2
    {
        public string EAN { get; set; }
        public int ProductQuantity { get; set; }
        public double NetworkGrossPrice { get; set; }
        public double NetworkNetPrice { get; set; }
        public object MedicalPrescription { get; set; }
    }

    public class SalesOrder
    {
        public List<SalesOrderItem2> SalesOrderItems { get; set; }
        public UniqueSequentialNumber UniqueSequentialNumber { get; set; }
        public NetworkInfo NetworkInfo { get; set; }
        public TaxFiscalReceipt TaxFiscalReceipt { get; set; }
        public string Source { get; set; }
        public string SalesDate { get; set; }
    }

    #endregion

    [TestClass]
    public class PedidoRep
    {
        string 
            url_base = "https://api-mng.interplayers.com.br/gip-pbm-api/api/",
                //"https://idp-api-gtw.azure-api.net/pbm-api-pre/api/"
            nsu = "";

        [TestMethod]
        public void PedidoRep1()
        {
            IRestResponse response;

            List<string> vec = new List<string>()
        {
"7891142203410",
"7898569766634",
"7896714290478",
"7896006219095",
"7896112169321",
"7896004743677",
"7891317118228",
"7898040326128",
"7891317020392",
"7896004763118",
"7896181914235",
"7896004731742",
"7896641804106",
"7896658038327",
"7891317137359",
"7898216372256"
        };

            List<Main> vec_main = new List<Main>()
        {
new Main { VirtualCardNumber="63957313023370311",SocialNumber="67192391395" },
new Main { VirtualCardNumber="63957313020193911",SocialNumber="	10400601532" },
new Main { VirtualCardNumber="63957313022064011",SocialNumber="	12303037077" },
new Main { VirtualCardNumber="63957313020041011",SocialNumber="	72089627743" },
new Main { VirtualCardNumber="63957313024195711",SocialNumber="	00794186947" },
new Main { VirtualCardNumber="63957313020703611",SocialNumber="	19556187987" },
new Main { VirtualCardNumber="63957313021340111",SocialNumber="	61273457072" },
new Main { VirtualCardNumber="63957313021333211",SocialNumber="	54524673431" },
new Main { VirtualCardNumber="63957313019757211",SocialNumber="	60538922460" },
new Main { VirtualCardNumber="63957313023313711",SocialNumber="	62533523348" },
new Main { VirtualCardNumber="63957313022245011",SocialNumber="	60745339620" },
new Main { VirtualCardNumber="63957313021801111",SocialNumber="	84712343869" },
new Main { VirtualCardNumber="63957313022221311",SocialNumber="	01629083690" },
new Main { VirtualCardNumber="63957313022938911",SocialNumber="	74145656539" },
new Main { VirtualCardNumber="63957313020611211	",SocialNumber="37902634514" },
new Main { VirtualCardNumber="63957313022747911",SocialNumber="	25817856328" },
new Main { VirtualCardNumber="63957313024261311",SocialNumber="	49456990036" },
new Main { VirtualCardNumber="63957313021045411",SocialNumber="	23059113866" },
new Main { VirtualCardNumber="63957313024362311",SocialNumber="	33130481613" },
new Main { VirtualCardNumber="63957313021737911",SocialNumber="	31686897006" },
new Main { VirtualCardNumber="63957313023079711",SocialNumber="	76835126809" },
new Main { VirtualCardNumber="63957313019543411	",SocialNumber="51533556164" },
new Main { VirtualCardNumber="63957313021021211",SocialNumber="	28290650183" },
new Main { VirtualCardNumber="63957313021078411",SocialNumber="	45144864503" },
new Main { VirtualCardNumber="63957313023988711",SocialNumber="	72418953807" },
new Main { VirtualCardNumber="63957313023887811",SocialNumber="	75512244086" },
new Main { VirtualCardNumber="63957313021741811",SocialNumber="	68535253297" },
new Main { VirtualCardNumber="63957313021556011",SocialNumber="	29952947810" },
new Main { VirtualCardNumber="63957313021578511	",SocialNumber="28769610401" },
new Main { VirtualCardNumber="63957313021720411",SocialNumber="	31817921959" },
new Main { VirtualCardNumber="63957313020800111",SocialNumber="	57455137486" },
new Main { VirtualCardNumber="63957313022655011",SocialNumber="	74273131862" },
new Main { VirtualCardNumber="63957313023321211",SocialNumber="	78157071305" },
new Main { VirtualCardNumber="63957313022115911	",SocialNumber="10635617951" },
new Main { VirtualCardNumber="63957313020502511",SocialNumber="	69683767761" },
new Main { VirtualCardNumber="63957313022826011",SocialNumber="	50129460737" },
new Main { VirtualCardNumber="63957313022617111",SocialNumber="	66371780042" },
new Main { VirtualCardNumber="63957313021497611",SocialNumber="	55230754001" },
new Main { VirtualCardNumber="63957313023280011",SocialNumber="	47288738701" },
new Main { VirtualCardNumber="63957313020654811",SocialNumber="	79555445605" },
new Main { VirtualCardNumber="63957313019977911",SocialNumber="	08198479767" },
new Main { VirtualCardNumber="63957313020199611",SocialNumber="	20196047285" },
new Main { VirtualCardNumber="63957313021568411",SocialNumber="	08488836597" },
new Main { VirtualCardNumber="63957313020160111",SocialNumber="	66896023899" },
new Main { VirtualCardNumber="63957313022803611",SocialNumber="	06559034372" },
new Main { VirtualCardNumber="63957313024183111",SocialNumber="	81020103396" },
new Main { VirtualCardNumber="63957313023552411",SocialNumber="	00844034207" },
new Main { VirtualCardNumber="63957313023657111",SocialNumber="	95457714454" },
new Main { VirtualCardNumber="63957313023302411",SocialNumber="	50955016940" },
new Main { VirtualCardNumber="63957313022189411",SocialNumber="	48438760201" },
new Main { VirtualCardNumber="63957313022742011",SocialNumber="	44522297009" },
new Main { VirtualCardNumber="63957313024303011",SocialNumber="	32420249909" },
new Main { VirtualCardNumber="63957313024304611",SocialNumber="	80928918696" },
new Main { VirtualCardNumber="63957313021612911",SocialNumber="	00185038298" },
new Main { VirtualCardNumber="63957313019951211",SocialNumber="	25806426092" },
new Main { VirtualCardNumber="63957313021587711",SocialNumber="	58446579936" },
new Main { VirtualCardNumber="63957313021387811",SocialNumber="	29866699803" },
new Main { VirtualCardNumber="63957313019997211",SocialNumber="	24640071531" },
new Main { VirtualCardNumber="63957313023712011",SocialNumber="	33465632354" },
new Main { VirtualCardNumber="63957313021653111",SocialNumber="	95706538174" },
new Main { VirtualCardNumber="63957313019495611",SocialNumber="	18961161911" },
new Main { VirtualCardNumber="63957313022668111",SocialNumber="	25368648472" },
new Main { VirtualCardNumber="63957313019649311",SocialNumber="	49619834038" },
new Main { VirtualCardNumber="63957313021260811",SocialNumber="	33337161782" },
new Main { VirtualCardNumber="63957313020784411",SocialNumber="	88610387941" },
new Main { VirtualCardNumber="63957313021653711",SocialNumber="	67563704728" },
new Main { VirtualCardNumber="63957313022760711",SocialNumber="	95465044322" },
new Main { VirtualCardNumber="63957313023384411",SocialNumber="	11320836992" },
new Main { VirtualCardNumber="63957313024038311",SocialNumber="	80089434595" },
new Main { VirtualCardNumber="63957313022392411",SocialNumber="	32690628694" },
new Main { VirtualCardNumber="63957313020323011",SocialNumber="	80114024472" },
new Main { VirtualCardNumber="63957313022542111",SocialNumber="	52311267647" },
new Main { VirtualCardNumber="63957313022726211",SocialNumber="	22751528813" },
new Main { VirtualCardNumber="63957313019653711",SocialNumber="	58963627144" },
new Main { VirtualCardNumber="63957313021338711",SocialNumber="	75298948111" },
new Main { VirtualCardNumber="63957313022381411",SocialNumber="	17991437833" },
new Main { VirtualCardNumber="63957313019427811",SocialNumber="	23320264958" },
new Main { VirtualCardNumber="63957313023040011",SocialNumber="	33499258200" },
new Main { VirtualCardNumber="63957313021859511",SocialNumber="	93137414741" },
new Main { VirtualCardNumber="63957313022082311",SocialNumber="	62844134084" },
new Main { VirtualCardNumber="63957313022603511",SocialNumber="	12029803766" },
new Main { VirtualCardNumber="63957313020708011",SocialNumber="	45072347435" },
new Main { VirtualCardNumber="63957313021978211",SocialNumber="	11681821826" },
new Main { VirtualCardNumber="63957313019986411",SocialNumber="	18681519484" },
new Main { VirtualCardNumber="63957313023633611",SocialNumber="	78347626219" },
new Main { VirtualCardNumber="63957313024224111",SocialNumber="	40449409406" },
new Main { VirtualCardNumber="63957313021858611",SocialNumber="	39074577300" },
new Main { VirtualCardNumber="63957313022080711",SocialNumber="	46760556097" },
new Main { VirtualCardNumber="63957313023619111",SocialNumber="	37310770943" },
new Main { VirtualCardNumber="63957313021013711",SocialNumber="	34613869528" },
new Main { VirtualCardNumber="63957313019785211",SocialNumber="	17044282202" },
new Main { VirtualCardNumber="63957313022793911",SocialNumber="	94299012658" },
new Main { VirtualCardNumber="63957313021575011",SocialNumber="	11827842679" },
new Main { VirtualCardNumber="63957313022016211",SocialNumber="	48309974604" },
new Main { VirtualCardNumber="63957313023690111",SocialNumber="	96311505690" },
new Main { VirtualCardNumber="63957313023580511",SocialNumber="	54138727477" },
new Main { VirtualCardNumber="63957313023930511",SocialNumber="	83286162701" },
new Main { VirtualCardNumber="63957313022441511",SocialNumber="	16033410807" },
new Main { VirtualCardNumber="63957313021884311",SocialNumber="	81688405186" },
new Main { VirtualCardNumber="63957313022035811",SocialNumber="	91146034709" },
new Main { VirtualCardNumber="63957313019883611	",SocialNumber="20864536208" },
new Main { VirtualCardNumber="63957313024103411",SocialNumber="	68542847911" },
new Main { VirtualCardNumber="63957313022631911",SocialNumber="	24801578497" },
new Main { VirtualCardNumber="63957313022644711",SocialNumber="	51412263441" },
new Main { VirtualCardNumber="63957313023045911",SocialNumber="	18014896106" },
new Main { VirtualCardNumber="63957313023332411",SocialNumber="	72215675730" },
new Main { VirtualCardNumber="63957313021886511",SocialNumber="	83664532600" },
new Main { VirtualCardNumber="63957313022749211",SocialNumber="	16483443056" },
new Main { VirtualCardNumber="63957313022371911	",SocialNumber="57226573873" },
new Main { VirtualCardNumber="63957313023135911",SocialNumber="	57718026892" },
new Main { VirtualCardNumber="63957313019495911",SocialNumber="	68619016520" },
new Main { VirtualCardNumber="63957313021256711	",SocialNumber="07608443561" },
new Main { VirtualCardNumber="63957313022919511",SocialNumber="	61776098307" },
new Main { VirtualCardNumber="63957313023526511",SocialNumber="	03500277225" },
new Main { VirtualCardNumber="63957313019775211",SocialNumber="	39094848406" },
new Main { VirtualCardNumber="63957313023743611",SocialNumber="	68207880023" },
new Main { VirtualCardNumber="63957313021774311	",SocialNumber="94250011623" },
new Main { VirtualCardNumber="63957313021040511",SocialNumber="	17138141610" },
new Main { VirtualCardNumber="63957313023801611",SocialNumber="	56605633849" },
new Main { VirtualCardNumber="63957313024277611",SocialNumber="	79841800403" },
new Main { VirtualCardNumber="63957313023432711",SocialNumber="	50248292048" },
new Main { VirtualCardNumber="63957313019654111",SocialNumber="	90415843901" },
new Main { VirtualCardNumber="63957313019929111",SocialNumber="	23051000353" },
new Main { VirtualCardNumber="63957313020458111",SocialNumber="	44010705000" },
new Main { VirtualCardNumber="63957313020875711",SocialNumber="	78923279080" },
new Main { VirtualCardNumber="63957313020958011",SocialNumber="	30173285899" },
new Main { VirtualCardNumber="63957313020672711",SocialNumber="	98216283709" },
new Main { VirtualCardNumber="63957313021757211",SocialNumber="	03485830100" },
new Main { VirtualCardNumber="63957313023062711",SocialNumber="	20472680609" },
new Main { VirtualCardNumber="63957313020903211",SocialNumber="	31538090970" },
new Main { VirtualCardNumber="63957313020664611",SocialNumber="	86589745536" },
new Main { VirtualCardNumber="63957313020806011",SocialNumber="	52102087107" },
new Main { VirtualCardNumber="63957313022459611",SocialNumber="	21519572174" },
new Main { VirtualCardNumber="63957313019898511",SocialNumber="	47020994504" },
new Main { VirtualCardNumber="63957313019813811",SocialNumber="	96589277699" },
new Main { VirtualCardNumber="63957313022003611",SocialNumber="	38376290908" },
new Main { VirtualCardNumber="63957313019816111	",SocialNumber="45580983832" },
new Main { VirtualCardNumber="63957313020687211",SocialNumber="	06821605394" },
new Main { VirtualCardNumber="63957313020261611	",SocialNumber="22418960986" },
new Main { VirtualCardNumber="63957313021778311",SocialNumber="	80073792152" },
new Main { VirtualCardNumber="63957313019710611",SocialNumber="	69080622958" },
new Main { VirtualCardNumber="63957313024050811",SocialNumber="	33729957678" },
new Main { VirtualCardNumber="63957313020355411	",SocialNumber="30857694472" },
new Main { VirtualCardNumber="63957313021451211",SocialNumber="	07934504462" },
new Main { VirtualCardNumber="63957313021191011	",SocialNumber="45835637608" },
new Main { VirtualCardNumber="63957313020804911",SocialNumber="	27291801419" },
new Main { VirtualCardNumber="63957313021073111",SocialNumber="	92542683484" },
new Main { VirtualCardNumber="63957313021647711",SocialNumber="	42177829267" },
new Main { VirtualCardNumber="63957313022766611",SocialNumber="	86444997771" },
new Main { VirtualCardNumber="63957313021886811",SocialNumber="	84695671875" },
new Main { VirtualCardNumber="63957313020187811",SocialNumber="	57569809203" },
new Main { VirtualCardNumber="63957313021817111",SocialNumber="	80416933777" },
new Main { VirtualCardNumber="63957313022259111	",SocialNumber="86314560632" },
new Main { VirtualCardNumber="63957313023247511	",SocialNumber="52913957960" },
new Main { VirtualCardNumber="63957313021529611",SocialNumber="	26823466855" },
new Main { VirtualCardNumber="63957313024085811",SocialNumber="	80397473923" },
new Main { VirtualCardNumber="63957313022800911",SocialNumber="	95108574169" },
new Main { VirtualCardNumber="63957313023643911",SocialNumber="	72796005810" },
new Main { VirtualCardNumber="63957313019608211",SocialNumber="	93867818169" },
new Main { VirtualCardNumber="63957313020042311",SocialNumber="	81435512294" },
new Main { VirtualCardNumber="63957313020857111",SocialNumber="	85422335570" },
new Main { VirtualCardNumber="63957313021392011",SocialNumber="	49764180736" },
new Main { VirtualCardNumber="63957313021847211",SocialNumber="	72633238939" },
new Main { VirtualCardNumber="63957313023981911",SocialNumber="	23585451713" },
new Main { VirtualCardNumber="63957313022582711",SocialNumber="	38647996941" },
new Main { VirtualCardNumber="63957313019440811",SocialNumber="	03767169592" },
new Main { VirtualCardNumber="63957313022275511",SocialNumber="	47941943662" },
new Main { VirtualCardNumber="63957313023781011",SocialNumber="	27456316406" },
new Main { VirtualCardNumber="63957313021195711",SocialNumber="	92390579787" },
new Main { VirtualCardNumber="63957313021581711",SocialNumber="	60503348627" },
new Main { VirtualCardNumber="63957313023309611",SocialNumber="	91014648335" },
new Main { VirtualCardNumber="63957313024337811",SocialNumber="	01635829399" },
new Main { VirtualCardNumber="63957313022575011",SocialNumber="	77279887902" },
new Main { VirtualCardNumber="63957313023386511",SocialNumber="	28894232123" },
new Main { VirtualCardNumber="63957313022000911",SocialNumber="	86879726798" },
new Main { VirtualCardNumber="63957313024251711	",SocialNumber="42690371642" },
new Main { VirtualCardNumber="63957313021360311",SocialNumber="	43755041960" },
new Main { VirtualCardNumber="63957313021134111",SocialNumber="	42167787553" },
new Main { VirtualCardNumber="63957313019436411",SocialNumber="	45291263237" },
new Main { VirtualCardNumber="63957313020835811",SocialNumber="	86264158429" },
new Main { VirtualCardNumber="63957313020637811",SocialNumber="	99248240089" },
new Main { VirtualCardNumber="63957313023217311	",SocialNumber="67066242920" },
new Main { VirtualCardNumber="63957313023327011",SocialNumber="	40762095911" },
new Main { VirtualCardNumber="63957313020988411",SocialNumber="	44946671889" },
new Main { VirtualCardNumber="63957313022056011",SocialNumber="	90820461725" },
new Main { VirtualCardNumber="63957313023388011",SocialNumber="	20734814933" },
new Main { VirtualCardNumber="63957313020086511",SocialNumber="	48838279179" },
new Main { VirtualCardNumber="63957313020374511",SocialNumber="	96024638132" },
new Main { VirtualCardNumber="63957313019581311",SocialNumber="	81597656062" },
new Main { VirtualCardNumber="63957313022310411",SocialNumber="	07504805211" },
new Main { VirtualCardNumber="63957313022001411",SocialNumber="	54026295109" },
new Main { VirtualCardNumber="63957313023045711",SocialNumber="	83810096938" },
new Main { VirtualCardNumber="63957313022618211",SocialNumber="	94998108034" },
new Main { VirtualCardNumber="63957313020754911",SocialNumber="	91547619058" },
new Main { VirtualCardNumber="63957313024024611",SocialNumber="	16895199080" },
new Main { VirtualCardNumber="63957313022252211",SocialNumber="	64180907720" },
new Main { VirtualCardNumber="63957313022440411",SocialNumber="	11546488774" },
new Main { VirtualCardNumber="63957313023577711",SocialNumber="	41595099670" },
new Main { VirtualCardNumber="63957313021727711",SocialNumber="	69803871706" },
new Main { VirtualCardNumber="63957313021633511",SocialNumber="	20085786586" },
         };

            // -----------------------
            // work!
            // -----------------------

            var _m = vec_main[new Random().Next(1, vec_main.Count)];
            var _p = vec[new Random().Next(1, vec.Count())];
            var _qtd = new Random().Next(1, 10);

            {
                var _client = new RestClient(url_base);
                var _request = new RestRequest(url_base + "pbm/preview-sales-order", Method.POST);

                _request.AddHeader("Content-Type", "application/json");

                _request.AddJsonBody(new PreviewSalesOrder
                {
                    Source = "DrugstoreDesk", Shopper = new Shopper { VirtualCardNumber = _m.VirtualCardNumber.Trim(), SocialNumber = _m.SocialNumber.Trim(), },
                    NetworkInfo = new NetworkInfo
                    {
                        Name = null,
                        FiscalNumber = "99999994002536",
                    },
                    State = new State
                    {
                        Name = "CE",
                        City = "FORTALEZA",
                        District = "CENTRO"
                    },
                    SalesOrderItems = new List<SalesOrderItem>
                    {
                        new SalesOrderItem
                        {
                            EAN = _p.Trim(),
                            ProductQuantity = _qtd,
                            MedicalPrescription = null,
                        }
                    }
                });

                var _response = _client.Execute(_request);

                var c = _response.StatusCode.ToString();

                _client.ClearHandlers();
            }

            {
                var _client = new RestClient(url_base);
                var _request = new RestRequest(url_base + "pbm/pre-sales-order", Method.POST);

                _request.AddHeader("Content-Type", "application/json");

                _request.AddJsonBody(new PreviewSalesOrder
                {
                    Source = "DrugstoreDesk",
                    Shopper = new Shopper
                    {
                        VirtualCardNumber = _m.VirtualCardNumber.Trim(),
                        SocialNumber = _m.SocialNumber.Trim(),
                    },
                    NetworkInfo = new NetworkInfo
                    {
                        Name = null,
                        FiscalNumber = "99999994002536",
                    },
                    State = new State
                    {
                        Name = "CE",
                        City = "FORTALEZA",
                        District = "CENTRO"
                    },
                    SalesOrderItems = new List<SalesOrderItem>
                                        {
                                            new SalesOrderItem
                                            {
                                                EAN = _p.Trim(),
                                                ProductQuantity = _qtd,
                                                MedicalPrescription = null,
                                            }
                                        }
                });

                var _response = _client.Execute(_request);

                var previewSalesOrderResp = JsonConvert.DeserializeObject<PreviewSalesOrderResp>(_response.Content);

                nsu = previewSalesOrderResp.UniqueSequentialNumber.Value.ToString();

                _client.ClearHandlers();
            }

            {
                var _client = new RestClient(url_base);
                var _request = new RestRequest(url_base + "pbm/sales-order", Method.POST);

                _request.AddHeader("Content-Type", "application/json");

                _request.AddJsonBody(new SalesOrder
                {
                    SalesOrderItems = new List<SalesOrderItem2> 
                    { 
                        new SalesOrderItem2
                        {
                            EAN = _p.Trim(),
                            ProductQuantity = _qtd,
                            NetworkGrossPrice = 65.90,
                            NetworkNetPrice = 52.00,
                            MedicalPrescription = null,
                        } 
                    },
                    UniqueSequentialNumber = new UniqueSequentialNumber
                    {
                        Value = nsu,
                    },
                    NetworkInfo = new NetworkInfo
                    {
                        FiscalNumber = "99999994002536",
                    },
                    TaxFiscalReceipt = new TaxFiscalReceipt
                    {
                        TaxNumber = "36598",
                        TaxType = "NFC",
                        AccessKey = "xxxx-xxxxx-xxxxx",
                    },
                    Source = "DrugstoreDesk",
                    SalesDate = "",
                });

                var _response = _client.Execute(_request);

                _client.ClearHandlers();
            }

            {
                var _client = new RestClient(url_base);
                var _request = new RestRequest(url_base + "pbm/sales-order/confirm", Method.POST);

                _request.AddHeader("Content-Type", "application/json");

                _request.AddJsonBody(new
                {
                    UniqueSequentialNumber = new UniqueSequentialNumber
                    {
                        Value = nsu,
                    },
                    TaxFiscalReceipt = new TaxFiscalReceipt
                    {
                        TaxNumber = "36598",
                        TaxType = "NFC",
                        AccessKey = "xxxx-xxxxx-xxxxx"
                    }
                });

                var _response = _client.Execute(_request);

                _client.ClearHandlers();
            }
            
        }

        public void PedidoRep2()
        {
            IRestResponse response;

            List<string> vec = new List<string>()
        {
"7891142203410",
"7898569766634",
"7896714290478",
"7896006219095",
"7896112169321",
"7896004743677",
"7891317118228",
"7898040326128",
"7891317020392",
"7896004763118",
"7896181914235",
"7896004731742",
"7896641804106",
"7896658038327",
"7891317137359",
"7898216372256"
        };

            List<Main> vec_main = new List<Main>()
        {
new Main { VirtualCardNumber="63957313023370311",SocialNumber="67192391395" },
new Main { VirtualCardNumber="63957313020193911",SocialNumber="	10400601532" },
new Main { VirtualCardNumber="63957313022064011",SocialNumber="	12303037077" },
new Main { VirtualCardNumber="63957313020041011",SocialNumber="	72089627743" },
new Main { VirtualCardNumber="63957313024195711",SocialNumber="	00794186947" },
new Main { VirtualCardNumber="63957313020703611",SocialNumber="	19556187987" },
new Main { VirtualCardNumber="63957313021340111",SocialNumber="	61273457072" },
new Main { VirtualCardNumber="63957313021333211",SocialNumber="	54524673431" },
new Main { VirtualCardNumber="63957313019757211",SocialNumber="	60538922460" },
new Main { VirtualCardNumber="63957313023313711",SocialNumber="	62533523348" },
new Main { VirtualCardNumber="63957313022245011",SocialNumber="	60745339620" },
new Main { VirtualCardNumber="63957313021801111",SocialNumber="	84712343869" },
new Main { VirtualCardNumber="63957313022221311",SocialNumber="	01629083690" },
new Main { VirtualCardNumber="63957313022938911",SocialNumber="	74145656539" },
new Main { VirtualCardNumber="63957313020611211	",SocialNumber="37902634514" },
new Main { VirtualCardNumber="63957313022747911",SocialNumber="	25817856328" },
new Main { VirtualCardNumber="63957313024261311",SocialNumber="	49456990036" },
new Main { VirtualCardNumber="63957313021045411",SocialNumber="	23059113866" },
new Main { VirtualCardNumber="63957313024362311",SocialNumber="	33130481613" },
new Main { VirtualCardNumber="63957313021737911",SocialNumber="	31686897006" },
new Main { VirtualCardNumber="63957313023079711",SocialNumber="	76835126809" },
new Main { VirtualCardNumber="63957313019543411	",SocialNumber="51533556164" },
new Main { VirtualCardNumber="63957313021021211",SocialNumber="	28290650183" },
new Main { VirtualCardNumber="63957313021078411",SocialNumber="	45144864503" },
new Main { VirtualCardNumber="63957313023988711",SocialNumber="	72418953807" },
new Main { VirtualCardNumber="63957313023887811",SocialNumber="	75512244086" },
new Main { VirtualCardNumber="63957313021741811",SocialNumber="	68535253297" },
new Main { VirtualCardNumber="63957313021556011",SocialNumber="	29952947810" },
new Main { VirtualCardNumber="63957313021578511	",SocialNumber="28769610401" },
new Main { VirtualCardNumber="63957313021720411",SocialNumber="	31817921959" },
new Main { VirtualCardNumber="63957313020800111",SocialNumber="	57455137486" },
new Main { VirtualCardNumber="63957313022655011",SocialNumber="	74273131862" },
new Main { VirtualCardNumber="63957313023321211",SocialNumber="	78157071305" },
new Main { VirtualCardNumber="63957313022115911	",SocialNumber="10635617951" },
new Main { VirtualCardNumber="63957313020502511",SocialNumber="	69683767761" },
new Main { VirtualCardNumber="63957313022826011",SocialNumber="	50129460737" },
new Main { VirtualCardNumber="63957313022617111",SocialNumber="	66371780042" },
new Main { VirtualCardNumber="63957313021497611",SocialNumber="	55230754001" },
new Main { VirtualCardNumber="63957313023280011",SocialNumber="	47288738701" },
new Main { VirtualCardNumber="63957313020654811",SocialNumber="	79555445605" },
new Main { VirtualCardNumber="63957313019977911",SocialNumber="	08198479767" },
new Main { VirtualCardNumber="63957313020199611",SocialNumber="	20196047285" },
new Main { VirtualCardNumber="63957313021568411",SocialNumber="	08488836597" },
new Main { VirtualCardNumber="63957313020160111",SocialNumber="	66896023899" },
new Main { VirtualCardNumber="63957313022803611",SocialNumber="	06559034372" },
new Main { VirtualCardNumber="63957313024183111",SocialNumber="	81020103396" },
new Main { VirtualCardNumber="63957313023552411",SocialNumber="	00844034207" },
new Main { VirtualCardNumber="63957313023657111",SocialNumber="	95457714454" },
new Main { VirtualCardNumber="63957313023302411",SocialNumber="	50955016940" },
new Main { VirtualCardNumber="63957313022189411",SocialNumber="	48438760201" },
new Main { VirtualCardNumber="63957313022742011",SocialNumber="	44522297009" },
new Main { VirtualCardNumber="63957313024303011",SocialNumber="	32420249909" },
new Main { VirtualCardNumber="63957313024304611",SocialNumber="	80928918696" },
new Main { VirtualCardNumber="63957313021612911",SocialNumber="	00185038298" },
new Main { VirtualCardNumber="63957313019951211",SocialNumber="	25806426092" },
new Main { VirtualCardNumber="63957313021587711",SocialNumber="	58446579936" },
new Main { VirtualCardNumber="63957313021387811",SocialNumber="	29866699803" },
new Main { VirtualCardNumber="63957313019997211",SocialNumber="	24640071531" },
new Main { VirtualCardNumber="63957313023712011",SocialNumber="	33465632354" },
new Main { VirtualCardNumber="63957313021653111",SocialNumber="	95706538174" },
new Main { VirtualCardNumber="63957313019495611",SocialNumber="	18961161911" },
new Main { VirtualCardNumber="63957313022668111",SocialNumber="	25368648472" },
new Main { VirtualCardNumber="63957313019649311",SocialNumber="	49619834038" },
new Main { VirtualCardNumber="63957313021260811",SocialNumber="	33337161782" },
new Main { VirtualCardNumber="63957313020784411",SocialNumber="	88610387941" },
new Main { VirtualCardNumber="63957313021653711",SocialNumber="	67563704728" },
new Main { VirtualCardNumber="63957313022760711",SocialNumber="	95465044322" },
new Main { VirtualCardNumber="63957313023384411",SocialNumber="	11320836992" },
new Main { VirtualCardNumber="63957313024038311",SocialNumber="	80089434595" },
new Main { VirtualCardNumber="63957313022392411",SocialNumber="	32690628694" },
new Main { VirtualCardNumber="63957313020323011",SocialNumber="	80114024472" },
new Main { VirtualCardNumber="63957313022542111",SocialNumber="	52311267647" },
new Main { VirtualCardNumber="63957313022726211",SocialNumber="	22751528813" },
new Main { VirtualCardNumber="63957313019653711",SocialNumber="	58963627144" },
new Main { VirtualCardNumber="63957313021338711",SocialNumber="	75298948111" },
new Main { VirtualCardNumber="63957313022381411",SocialNumber="	17991437833" },
new Main { VirtualCardNumber="63957313019427811",SocialNumber="	23320264958" },
new Main { VirtualCardNumber="63957313023040011",SocialNumber="	33499258200" },
new Main { VirtualCardNumber="63957313021859511",SocialNumber="	93137414741" },
new Main { VirtualCardNumber="63957313022082311",SocialNumber="	62844134084" },
new Main { VirtualCardNumber="63957313022603511",SocialNumber="	12029803766" },
new Main { VirtualCardNumber="63957313020708011",SocialNumber="	45072347435" },
new Main { VirtualCardNumber="63957313021978211",SocialNumber="	11681821826" },
new Main { VirtualCardNumber="63957313019986411",SocialNumber="	18681519484" },
new Main { VirtualCardNumber="63957313023633611",SocialNumber="	78347626219" },
new Main { VirtualCardNumber="63957313024224111",SocialNumber="	40449409406" },
new Main { VirtualCardNumber="63957313021858611",SocialNumber="	39074577300" },
new Main { VirtualCardNumber="63957313022080711",SocialNumber="	46760556097" },
new Main { VirtualCardNumber="63957313023619111",SocialNumber="	37310770943" },
new Main { VirtualCardNumber="63957313021013711",SocialNumber="	34613869528" },
new Main { VirtualCardNumber="63957313019785211",SocialNumber="	17044282202" },
new Main { VirtualCardNumber="63957313022793911",SocialNumber="	94299012658" },
new Main { VirtualCardNumber="63957313021575011",SocialNumber="	11827842679" },
new Main { VirtualCardNumber="63957313022016211",SocialNumber="	48309974604" },
new Main { VirtualCardNumber="63957313023690111",SocialNumber="	96311505690" },
new Main { VirtualCardNumber="63957313023580511",SocialNumber="	54138727477" },
new Main { VirtualCardNumber="63957313023930511",SocialNumber="	83286162701" },
new Main { VirtualCardNumber="63957313022441511",SocialNumber="	16033410807" },
new Main { VirtualCardNumber="63957313021884311",SocialNumber="	81688405186" },
new Main { VirtualCardNumber="63957313022035811",SocialNumber="	91146034709" },
new Main { VirtualCardNumber="63957313019883611	",SocialNumber="20864536208" },
new Main { VirtualCardNumber="63957313024103411",SocialNumber="	68542847911" },
new Main { VirtualCardNumber="63957313022631911",SocialNumber="	24801578497" },
new Main { VirtualCardNumber="63957313022644711",SocialNumber="	51412263441" },
new Main { VirtualCardNumber="63957313023045911",SocialNumber="	18014896106" },
new Main { VirtualCardNumber="63957313023332411",SocialNumber="	72215675730" },
new Main { VirtualCardNumber="63957313021886511",SocialNumber="	83664532600" },
new Main { VirtualCardNumber="63957313022749211",SocialNumber="	16483443056" },
new Main { VirtualCardNumber="63957313022371911	",SocialNumber="57226573873" },
new Main { VirtualCardNumber="63957313023135911",SocialNumber="	57718026892" },
new Main { VirtualCardNumber="63957313019495911",SocialNumber="	68619016520" },
new Main { VirtualCardNumber="63957313021256711	",SocialNumber="07608443561" },
new Main { VirtualCardNumber="63957313022919511",SocialNumber="	61776098307" },
new Main { VirtualCardNumber="63957313023526511",SocialNumber="	03500277225" },
new Main { VirtualCardNumber="63957313019775211",SocialNumber="	39094848406" },
new Main { VirtualCardNumber="63957313023743611",SocialNumber="	68207880023" },
new Main { VirtualCardNumber="63957313021774311	",SocialNumber="94250011623" },
new Main { VirtualCardNumber="63957313021040511",SocialNumber="	17138141610" },
new Main { VirtualCardNumber="63957313023801611",SocialNumber="	56605633849" },
new Main { VirtualCardNumber="63957313024277611",SocialNumber="	79841800403" },
new Main { VirtualCardNumber="63957313023432711",SocialNumber="	50248292048" },
new Main { VirtualCardNumber="63957313019654111",SocialNumber="	90415843901" },
new Main { VirtualCardNumber="63957313019929111",SocialNumber="	23051000353" },
new Main { VirtualCardNumber="63957313020458111",SocialNumber="	44010705000" },
new Main { VirtualCardNumber="63957313020875711",SocialNumber="	78923279080" },
new Main { VirtualCardNumber="63957313020958011",SocialNumber="	30173285899" },
new Main { VirtualCardNumber="63957313020672711",SocialNumber="	98216283709" },
new Main { VirtualCardNumber="63957313021757211",SocialNumber="	03485830100" },
new Main { VirtualCardNumber="63957313023062711",SocialNumber="	20472680609" },
new Main { VirtualCardNumber="63957313020903211",SocialNumber="	31538090970" },
new Main { VirtualCardNumber="63957313020664611",SocialNumber="	86589745536" },
new Main { VirtualCardNumber="63957313020806011",SocialNumber="	52102087107" },
new Main { VirtualCardNumber="63957313022459611",SocialNumber="	21519572174" },
new Main { VirtualCardNumber="63957313019898511",SocialNumber="	47020994504" },
new Main { VirtualCardNumber="63957313019813811",SocialNumber="	96589277699" },
new Main { VirtualCardNumber="63957313022003611",SocialNumber="	38376290908" },
new Main { VirtualCardNumber="63957313019816111	",SocialNumber="45580983832" },
new Main { VirtualCardNumber="63957313020687211",SocialNumber="	06821605394" },
new Main { VirtualCardNumber="63957313020261611	",SocialNumber="22418960986" },
new Main { VirtualCardNumber="63957313021778311",SocialNumber="	80073792152" },
new Main { VirtualCardNumber="63957313019710611",SocialNumber="	69080622958" },
new Main { VirtualCardNumber="63957313024050811",SocialNumber="	33729957678" },
new Main { VirtualCardNumber="63957313020355411	",SocialNumber="30857694472" },
new Main { VirtualCardNumber="63957313021451211",SocialNumber="	07934504462" },
new Main { VirtualCardNumber="63957313021191011	",SocialNumber="45835637608" },
new Main { VirtualCardNumber="63957313020804911",SocialNumber="	27291801419" },
new Main { VirtualCardNumber="63957313021073111",SocialNumber="	92542683484" },
new Main { VirtualCardNumber="63957313021647711",SocialNumber="	42177829267" },
new Main { VirtualCardNumber="63957313022766611",SocialNumber="	86444997771" },
new Main { VirtualCardNumber="63957313021886811",SocialNumber="	84695671875" },
new Main { VirtualCardNumber="63957313020187811",SocialNumber="	57569809203" },
new Main { VirtualCardNumber="63957313021817111",SocialNumber="	80416933777" },
new Main { VirtualCardNumber="63957313022259111	",SocialNumber="86314560632" },
new Main { VirtualCardNumber="63957313023247511	",SocialNumber="52913957960" },
new Main { VirtualCardNumber="63957313021529611",SocialNumber="	26823466855" },
new Main { VirtualCardNumber="63957313024085811",SocialNumber="	80397473923" },
new Main { VirtualCardNumber="63957313022800911",SocialNumber="	95108574169" },
new Main { VirtualCardNumber="63957313023643911",SocialNumber="	72796005810" },
new Main { VirtualCardNumber="63957313019608211",SocialNumber="	93867818169" },
new Main { VirtualCardNumber="63957313020042311",SocialNumber="	81435512294" },
new Main { VirtualCardNumber="63957313020857111",SocialNumber="	85422335570" },
new Main { VirtualCardNumber="63957313021392011",SocialNumber="	49764180736" },
new Main { VirtualCardNumber="63957313021847211",SocialNumber="	72633238939" },
new Main { VirtualCardNumber="63957313023981911",SocialNumber="	23585451713" },
new Main { VirtualCardNumber="63957313022582711",SocialNumber="	38647996941" },
new Main { VirtualCardNumber="63957313019440811",SocialNumber="	03767169592" },
new Main { VirtualCardNumber="63957313022275511",SocialNumber="	47941943662" },
new Main { VirtualCardNumber="63957313023781011",SocialNumber="	27456316406" },
new Main { VirtualCardNumber="63957313021195711",SocialNumber="	92390579787" },
new Main { VirtualCardNumber="63957313021581711",SocialNumber="	60503348627" },
new Main { VirtualCardNumber="63957313023309611",SocialNumber="	91014648335" },
new Main { VirtualCardNumber="63957313024337811",SocialNumber="	01635829399" },
new Main { VirtualCardNumber="63957313022575011",SocialNumber="	77279887902" },
new Main { VirtualCardNumber="63957313023386511",SocialNumber="	28894232123" },
new Main { VirtualCardNumber="63957313022000911",SocialNumber="	86879726798" },
new Main { VirtualCardNumber="63957313024251711	",SocialNumber="42690371642" },
new Main { VirtualCardNumber="63957313021360311",SocialNumber="	43755041960" },
new Main { VirtualCardNumber="63957313021134111",SocialNumber="	42167787553" },
new Main { VirtualCardNumber="63957313019436411",SocialNumber="	45291263237" },
new Main { VirtualCardNumber="63957313020835811",SocialNumber="	86264158429" },
new Main { VirtualCardNumber="63957313020637811",SocialNumber="	99248240089" },
new Main { VirtualCardNumber="63957313023217311	",SocialNumber="67066242920" },
new Main { VirtualCardNumber="63957313023327011",SocialNumber="	40762095911" },
new Main { VirtualCardNumber="63957313020988411",SocialNumber="	44946671889" },
new Main { VirtualCardNumber="63957313022056011",SocialNumber="	90820461725" },
new Main { VirtualCardNumber="63957313023388011",SocialNumber="	20734814933" },
new Main { VirtualCardNumber="63957313020086511",SocialNumber="	48838279179" },
new Main { VirtualCardNumber="63957313020374511",SocialNumber="	96024638132" },
new Main { VirtualCardNumber="63957313019581311",SocialNumber="	81597656062" },
new Main { VirtualCardNumber="63957313022310411",SocialNumber="	07504805211" },
new Main { VirtualCardNumber="63957313022001411",SocialNumber="	54026295109" },
new Main { VirtualCardNumber="63957313023045711",SocialNumber="	83810096938" },
new Main { VirtualCardNumber="63957313022618211",SocialNumber="	94998108034" },
new Main { VirtualCardNumber="63957313020754911",SocialNumber="	91547619058" },
new Main { VirtualCardNumber="63957313024024611",SocialNumber="	16895199080" },
new Main { VirtualCardNumber="63957313022252211",SocialNumber="	64180907720" },
new Main { VirtualCardNumber="63957313022440411",SocialNumber="	11546488774" },
new Main { VirtualCardNumber="63957313023577711",SocialNumber="	41595099670" },
new Main { VirtualCardNumber="63957313021727711",SocialNumber="	69803871706" },
new Main { VirtualCardNumber="63957313021633511",SocialNumber="	20085786586" },
         };

            // -----------------------
            // work!
            // -----------------------

            var _m = vec_main[new Random().Next(1, vec_main.Count)];
            var _p = vec[new Random().Next(1, vec.Count())];
            var _qtd = new Random().Next(1, 10);

            {
                var _client = new RestClient(url_base);
                var _request = new RestRequest(url_base + "pbm/preview-sales-order", Method.POST);

                _request.AddHeader("Content-Type", "application/json");

                _request.AddJsonBody(new PreviewSalesOrder
                {
                    Source = "DrugstoreDesk",
                    Shopper = new Shopper { VirtualCardNumber = _m.VirtualCardNumber.Trim(), SocialNumber = _m.SocialNumber.Trim(), },
                    NetworkInfo = new NetworkInfo
                    {
                        Name = null,
                        FiscalNumber = "99999994002536",
                    },
                    State = new State
                    {
                        Name = "CE",
                        City = "FORTALEZA",
                        District = "CENTRO"
                    },
                    SalesOrderItems = new List<SalesOrderItem>
                    {
                        new SalesOrderItem
                        {
                            EAN = _p.Trim(),
                            ProductQuantity = _qtd,
                            MedicalPrescription = null,
                        }
                    }
                });

                var _response = _client.Execute(_request);

                var c = _response.StatusCode.ToString();

                _client.ClearHandlers();
            }

            {
                var _client = new RestClient(url_base);
                var _request = new RestRequest(url_base + "pbm/pre-sales-order", Method.POST);

                _request.AddHeader("Content-Type", "application/json");

                _request.AddJsonBody(new PreviewSalesOrder
                {
                    Source = "DrugstoreDesk",
                    Shopper = new Shopper
                    {
                        VirtualCardNumber = _m.VirtualCardNumber.Trim(),
                        SocialNumber = _m.SocialNumber.Trim(),
                    },
                    NetworkInfo = new NetworkInfo
                    {
                        Name = null,
                        FiscalNumber = "99999994002536",
                    },
                    State = new State
                    {
                        Name = "CE",
                        City = "FORTALEZA",
                        District = "CENTRO"
                    },
                    SalesOrderItems = new List<SalesOrderItem>
                                        {
                                            new SalesOrderItem
                                            {
                                                EAN = _p.Trim(),
                                                ProductQuantity = _qtd,
                                                MedicalPrescription = null,
                                            }
                                        }
                });

                var _response = _client.Execute(_request);

                var previewSalesOrderResp = JsonConvert.DeserializeObject<PreviewSalesOrderResp>(_response.Content);

                nsu = previewSalesOrderResp.UniqueSequentialNumber.Value.ToString();

                _client.ClearHandlers();
            }

            {
                var _client = new RestClient(url_base);
                var _request = new RestRequest(url_base + "pbm/sales-order", Method.POST);

                _request.AddHeader("Content-Type", "application/json");

                _request.AddJsonBody(new SalesOrder
                {
                    SalesOrderItems = new List<SalesOrderItem2>
                    {
                        new SalesOrderItem2
                        {
                            EAN = _p.Trim(),
                            ProductQuantity = _qtd,
                            NetworkGrossPrice = 65.90,
                            NetworkNetPrice = 52.00,
                            MedicalPrescription = null,
                        }
                    },
                    UniqueSequentialNumber = new UniqueSequentialNumber
                    {
                        Value = nsu,
                    },
                    NetworkInfo = new NetworkInfo
                    {
                        FiscalNumber = "99999994002536",
                    },
                    TaxFiscalReceipt = new TaxFiscalReceipt
                    {
                        TaxNumber = "36598",
                        TaxType = "NFC",
                        AccessKey = "xxxx-xxxxx-xxxxx",
                    },
                    Source = "DrugstoreDesk",
                    SalesDate = "",
                });

                var _response = _client.Execute(_request);

                _client.ClearHandlers();
            }

            {
                var _client = new RestClient(url_base);
                var _request = new RestRequest(url_base + "pbm/sales-order/confirm", Method.POST);

                _request.AddHeader("Content-Type", "application/json");

                _request.AddJsonBody(new
                {
                    UniqueSequentialNumber = new UniqueSequentialNumber
                    {
                        Value = nsu,
                    },
                    TaxFiscalReceipt = new TaxFiscalReceipt
                    {
                        TaxNumber = "36598",
                        TaxType = "NFC",
                        AccessKey = "xxxx-xxxxx-xxxxx"
                    }
                });

                var _response = _client.Execute(_request);

                _client.ClearHandlers();
            }

        }
    }
}