using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Xml.Serialization;

namespace ConsoleApp1.Model
{
    [XmlRoot(ElementName = "CEB311Message", Namespace = "http://www.chinaport.gov.cn/ceb")]
    public class CEB311Message
    {
        private string guid;

        [XmlAttribute("guid")]
        public string Guid
        {
            get { return guid.ToUpper(); }
            set { guid = value; }
        }

        [XmlAttribute("version")]
        [DefaultValue("1.0")]
        private string version; 
        public string Version
        {
            get { return version; }
            set { version = value; }
        }

        private Order[] orders = null;
        [XmlArray("Order")]
        public Order[] Orders
        {
            get { return orders;}
            set { orders = value; }
        }
        private BaseTransfer baseTransfer;

        public BaseTransfer BaseTransfer
        {
            get { return baseTransfer; }
            set { baseTransfer = value; }
        }

        private Signature signature;

        [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public Signature Signature
        {
            get { return signature; }
            set { signature = value; }
        }




    }

    public class Order
    {
        private OrderHead orderHead;

        public OrderHead OrderHead
        {
            get { return orderHead; }
            set { orderHead = value; }
        }

        private OrderList orderList;

        public OrderList OrderList
        {
            get { return orderList; }
            set { orderList = value; }
        }



    }

    public class OrderHead
    {
        private string guid;

        public string Guid
        {
            get { return guid; }
            set { guid = value; }
        }
        private string appType;

        public string AppType
        {
            get { return appType; }
            set { appType = value; }
        }
        private string appTime;

        public string AppTime
        {
            get { return appTime; }
            set { appTime = value; }
        }
        private string appStatus;

        public string AppStatus
        {
            get { return appStatus; }
            set { appStatus = value; }
        }
        private string orderType;

        public string OrderType
        {
            get { return orderType; }
            set { orderType = value; }
        }
        private string orderNo;

        public string OrderNo
        {
            get { return orderNo; }
            set { orderNo = value; }
        }
        private string ebpCode;

        public string EbpCode
        {
            get { return ebpCode; }
            set { ebpCode = value; }
        }
        private string ebpName;

        public string EbpName
        {
            get { return ebpName; }
            set { ebpName = value; }
        }
        private string ebcCode;

        public string EbcCode
        {
            get { return ebcCode; }
            set { ebcCode = value; }
        }

        private string ebcName;

        public string EbcName
        {
            get { return ebcName; }
            set { ebcName = value; }
        }
        private string goodsValue;

        public string GoodsValue
        {
            get { return goodsValue; }
            set { goodsValue = value; }
        }
        private string freight;

        public string Freight
        {
            get { return freight; }
            set { freight = value; }
        }
        private string currency;

        public string Currency
        {
            get { return currency; }
            set { currency = value; }
        }
        private string note;

        public string Note
        {
            get { return note; }
            set { note = value; }
        }


    }

    public class OrderList
    {
        private string gnum;

        public string Gnum
        {
            get { return gnum; }
            set { gnum = value; }
        }
        private string itemNo;

        public string ItemNo
        {
            get { return itemNo; }
            set { itemNo = value; }
        }
        private string itemName;

        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }
        private string itemDescribe;

        public string ItemDescribe
        {
            get { return itemDescribe; }
            set { itemDescribe = value; }
        }
        private string barCode;

        public string BarCode
        {
            get { return barCode; }
            set { barCode = value; }
        }
        private string unit;

        public string Unit
        {
            get { return unit; }
            set { unit = value; }
        }
        private string currency;

        public string Currency
        {
            get { return currency; }
            set { currency = value; }
        }
        private string qty;

        public string Qty
        {
            get { return qty; }
            set { qty = value; }
        }
        private string price;

        public string Price
        {
            get { return price; }
            set { price = value; }
        }
        private string totalPrice;

        public string TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }
        private string note;

        public string Note
        {
            get { return note; }
            set { note = value; }
        }



    }

    public class BaseTransfer
    {
        private string copCode;

        public string CopCode
        {
            get { return copCode; }
            set { copCode = value; }
        }
        private string copName;

        public string CopName
        {
            get { return copName; }
            set { copName = value; }
        }
        private string dxpMode;

        public string DxpMode
        {
            get { return dxpMode; }
            set { dxpMode = value; }
        }
        private string dxpId;

        public string DxpId
        {
            get { return dxpId; }
            set { dxpId = value; }
        }
        private string note;

        public string Note
        {
            get { return note; }
            set { note = value; }
        }


    }

    public class Signature
    {

    }
    public class SignedInfo
    {
        private string canonicalizationMethod;

        public string CanonicalizationMethod
        {
            get { return canonicalizationMethod; }
            set { canonicalizationMethod = value; }
        }
        private string signatureMethod;

        public string SignatureMethod
        {
            get { return signatureMethod; }
            set { signatureMethod = value; }
        } 

    }
    public class Transforms
    {

    }
}
