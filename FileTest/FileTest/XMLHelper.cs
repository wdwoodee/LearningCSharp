using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace FileTest
{
    class XMLHelper
    {
        public XMLHelper()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region XML文档节点查询和读取
        ///<summary>
        /// 选择匹配XPath表达式的第一个节点XmlNode.
        ///</summary>
        ///<param name="xmlFileName">XML文档完全文件名(包含物理路径)</param>
        ///<param name="xpath">要匹配的XPath表达式(例如:"//节点名//子节点名")</param>
        ///<returns>返回XmlNode</returns>
        public static XmlNode GetXmlNodeByXpath(string xmlFileName, string xpath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(xmlFileName); //加载XML文档
                XmlNode xmlNode = xmlDoc.SelectSingleNode(xpath);
                return xmlNode;
            }
            catch (Exception ex)
            {
                return null;
                //throw ex; //这里可以定义你自己的异常处理
            }
        }

        ///<summary>
        /// 选择匹配XPath表达式的节点列表XmlNodeList.
        ///</summary>
        ///<param name="xmlFileName">XML文档完全文件名(包含物理路径)</param>
        ///<param name="xpath">要匹配的XPath表达式(例如:"//节点名//子节点名")</param>
        ///<returns>返回XmlNodeList</returns>
        public static XmlNodeList GetXmlNodeListByXpath(string xmlFileName, string xpath)
        {
            XmlDocument xmlDoc = new XmlDocument();

            try
            {
                xmlDoc.Load(xmlFileName); //加载XML文档
                XmlNodeList xmlNodeList = xmlDoc.SelectNodes(xpath);
                return xmlNodeList;
            }
            catch (Exception ex)
            {
                return null;
                //throw ex; //这里可以定义你自己的异常处理
            }
        }

        ///<summary>
        /// 选择匹配XPath表达式的第一个节点的匹配xmlAttributeName的属性XmlAttribute.
        ///</summary>
        ///<param name="xmlFileName">XML文档完全文件名(包含物理路径)</param>
        ///<param name="xpath">要匹配的XPath表达式(例如:"//节点名//子节点名</param>
        ///<param name="xmlAttributeName">要匹配xmlAttributeName的属性名称</param>
        ///<returns>返回xmlAttributeName</returns>
        public static XmlAttribute GetXmlAttribute(string xmlFileName, string xpath, string xmlAttributeName)
        {
            string content = string.Empty;
            XmlDocument xmlDoc = new XmlDocument();
            XmlAttribute xmlAttribute = null;
            try
            {
                xmlDoc.Load(xmlFileName); //加载XML文档
                XmlNode xmlNode = xmlDoc.SelectSingleNode(xpath);
                if (xmlNode != null)
                {
                    if (xmlNode.Attributes.Count > 0)
                    {
                        xmlAttribute = xmlNode.Attributes[xmlAttributeName];
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex; //这里可以定义你自己的异常处理
            }
            return xmlAttribute;
        }
        #endregion

        #region XML文档创建和节点或属性的添加、修改
        ///<summary>
        /// 创建一个XML文档
        ///</summary>
        ///<param name="xmlFileName">XML文档完全文件名(包含物理路径)</param>
        ///<param name="rootNodeName">XML文档根节点名称(须指定一个根节点名称)</param>
        ///<param name="version">XML文档版本号(必须为:"1.0")</param>
        ///<param name="encoding">XML文档编码方式</param>
        ///<param name="standalone">该值必须是"yes"或"no",如果为null,Save方法不在XML声明上写出独立属性</param>
        ///<returns>成功返回true,失败返回false</returns>
        public static bool CreateXmlDocument(string xmlFileName, string rootNodeName, string version, string encoding, string standalone)
        {
            bool isSuccess = false;
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration(version, encoding, standalone);
                XmlNode root = xmlDoc.CreateElement(rootNodeName);
                xmlDoc.AppendChild(xmlDeclaration);
                xmlDoc.AppendChild(root);
                xmlDoc.Save(xmlFileName);
                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw ex; //这里可以定义你自己的异常处理
            }
            return isSuccess;
        }

        ///<summary>
        /// 依据匹配XPath表达式的第一个节点来创建它的子节点(如果此节点已存在则追加一个新的同名节点
        ///</summary>
        ///<param name="xmlFileName">XML文档完全文件名(包含物理路径)</param>
        ///<param name="xpath">要匹配的XPath表达式(例如:"//节点名//子节点名</param>
        ///<param name="xmlNodeName">要匹配xmlNodeName的节点名称</param>
        ///<param name="innerText">节点文本值</param>
        ///<param name="xmlAttributeName">要匹配xmlAttributeName的属性名称</param>
        ///<param name="value">属性值</param>
        ///<returns>成功返回true,失败返回false</returns>
        public static bool CreateXmlNodeByXPath(string xmlFileName, string xpath, string xmlNodeName, string innerText, string xmlAttributeName, string value)
        {
            bool isSuccess = false;
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(xmlFileName); //加载XML文档
                XmlNode xmlNode = xmlDoc.SelectSingleNode(xpath);
                if (xmlNode != null)
                {
                    //存不存在此节点都创建
                    XmlElement subElement = xmlDoc.CreateElement(xmlNodeName);
                    subElement.InnerXml = innerText;

                    //如果属性和值参数都不为空则在此新节点上新增属性
                    if (!string.IsNullOrEmpty(xmlAttributeName) && !string.IsNullOrEmpty(value))
                    {
                        XmlAttribute xmlAttribute = xmlDoc.CreateAttribute(xmlAttributeName);
                        xmlAttribute.Value = value;
                        subElement.Attributes.Append(xmlAttribute);
                    }

                    xmlNode.AppendChild(subElement);
                }
                xmlDoc.Save(xmlFileName); //保存到XML文档
                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw ex; //这里可以定义你自己的异常处理
            }
            return isSuccess;
        }

        ///<summary>
        /// 依据匹配XPath表达式的第一个节点来创建或更新它的子节点(如果节点存在则更新,不存在则创建)
        ///</summary>
        ///<param name="xmlFileName">XML文档完全文件名(包含物理路径)</param>
        ///<param name="xpath">要匹配的XPath表达式(例如:"//节点名//子节点名</param>
        ///<param name="xmlNodeName">要匹配xmlNodeName的节点名称</param>
        ///<param name="innerText">节点文本值</param>
        ///<returns>成功返回true,失败返回false</returns>
        public static bool CreateOrUpdateXmlNodeByXPath(string xmlFileName, string xpath, string xmlNodeName, string innerText)
        {
            bool isSuccess = false;
            bool isExistsNode = false;//标识节点是否存在
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(xmlFileName); //加载XML文档
                XmlNode xmlNode = xmlDoc.SelectSingleNode(xpath);
                if (xmlNode != null)
                {
                    //遍历xpath节点下的所有子节点
                    foreach (XmlNode node in xmlNode.ChildNodes)
                    {
                        if (node.Name.ToLower() == xmlNodeName.ToLower())
                        {
                            //存在此节点则更新
                            node.InnerXml = innerText;
                            isExistsNode = true;
                            break;
                        }
                    }
                    if (!isExistsNode)
                    {
                        //不存在此节点则创建
                        XmlElement subElement = xmlDoc.CreateElement(xmlNodeName);
                        subElement.InnerXml = innerText;
                        xmlNode.AppendChild(subElement);
                    }
                }
                xmlDoc.Save(xmlFileName); //保存到XML文档
                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw ex; //这里可以定义你自己的异常处理
            }
            return isSuccess;
        }

        ///<summary>
        /// 依据匹配XPath表达式的第一个节点来创建或更新它的属性(如果属性存在则更新,不存在则创建)
        ///</summary>
        ///<param name="xmlFileName">XML文档完全文件名(包含物理路径)</param>
        ///<param name="xpath">要匹配的XPath表达式(例如:"//节点名//子节点名</param>
        ///<param name="xmlAttributeName">要匹配xmlAttributeName的属性名称</param>
        ///<param name="value">属性值</param>
        ///<returns>成功返回true,失败返回false</returns>
        public static bool CreateOrUpdateXmlAttributeByXPath(string xmlFileName, string xpath, string xmlAttributeName, string value)
        {
            bool isSuccess = false;
            bool isExistsAttribute = false;//标识属性是否存在
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(xmlFileName); //加载XML文档
                XmlNode xmlNode = xmlDoc.SelectSingleNode(xpath);
                if (xmlNode != null)
                {
                    //遍历xpath节点中的所有属性
                    foreach (XmlAttribute attribute in xmlNode.Attributes)
                    {
                        if (attribute.Name.ToLower() == xmlAttributeName.ToLower())
                        {
                            //节点中存在此属性则更新
                            attribute.Value = value;
                            isExistsAttribute = true;
                            break;
                        }
                    }
                    if (!isExistsAttribute)
                    {
                        //节点中不存在此属性则创建
                        XmlAttribute xmlAttribute = xmlDoc.CreateAttribute(xmlAttributeName);
                        xmlAttribute.Value = value;
                        xmlNode.Attributes.Append(xmlAttribute);
                    }
                }
                xmlDoc.Save(xmlFileName); //保存到XML文档
                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw ex; //这里可以定义你自己的异常处理
            }
            return isSuccess;
        }
        #endregion

        #region XML文档节点或属性的删除
        ///<summary>
        /// 删除匹配XPath表达式的第一个节点(节点中的子元素同时会被删除)
        ///</summary>
        ///<param name="xmlFileName">XML文档完全文件名(包含物理路径)</param>
        ///<param name="xpath">要匹配的XPath表达式(例如:"//节点名//子节点名</param>
        ///<returns>成功返回true,失败返回false</returns>
        public static bool DeleteXmlNodeByXPath(string xmlFileName, string xpath)
        {
            bool isSuccess = false;
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(xmlFileName); //加载XML文档
                XmlNode xmlNode = xmlDoc.SelectSingleNode(xpath);
                if (xmlNode != null)
                {
                    //删除节点
                    xmlNode.ParentNode.RemoveChild(xmlNode);
                }
                xmlDoc.Save(xmlFileName); //保存到XML文档
                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw ex; //这里可以定义你自己的异常处理
            }
            return isSuccess;
        }

        ///<summary>
        /// 删除匹配XPath表达式的第一个节点中的匹配参数xmlAttributeName的属性
        ///</summary>
        ///<param name="xmlFileName">XML文档完全文件名(包含物理路径)</param>
        ///<param name="xpath">要匹配的XPath表达式(例如:"//节点名//子节点名</param>
        ///<param name="xmlAttributeName">要删除的xmlAttributeName的属性名称</param>
        ///<returns>成功返回true,失败返回false</returns>
        public static bool DeleteXmlAttributeByXPath(string xmlFileName, string xpath, string xmlAttributeName)
        {
            bool isSuccess = false;
            bool isExistsAttribute = false;
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(xmlFileName); //加载XML文档
                XmlNode xmlNode = xmlDoc.SelectSingleNode(xpath);
                XmlAttribute xmlAttribute = null;
                if (xmlNode != null)
                {
                    //遍历xpath节点中的所有属性
                    foreach (XmlAttribute attribute in xmlNode.Attributes)
                    {
                        if (attribute.Name.ToLower() == xmlAttributeName.ToLower())
                        {
                            //节点中存在此属性
                            xmlAttribute = attribute;
                            isExistsAttribute = true;
                            break;
                        }
                    }
                    if (isExistsAttribute)
                    {
                        //删除节点中的属性
                        xmlNode.Attributes.Remove(xmlAttribute);
                    }
                }
                xmlDoc.Save(xmlFileName); //保存到XML文档
                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw ex; //这里可以定义你自己的异常处理
            }
            return isSuccess;
        }

        ///<summary>
        /// 删除匹配XPath表达式的第一个节点中的所有属性
        ///</summary>
        ///<param name="xmlFileName">XML文档完全文件名(包含物理路径)</param>
        ///<param name="xpath">要匹配的XPath表达式(例如:"//节点名//子节点名</param>
        ///<returns>成功返回true,失败返回false</returns>
        public static bool DeleteAllXmlAttributeByXPath(string xmlFileName, string xpath)
        {
            bool isSuccess = false;
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(xmlFileName); //加载XML文档
                XmlNode xmlNode = xmlDoc.SelectSingleNode(xpath);
                if (xmlNode != null)
                {
                    //遍历xpath节点中的所有属性
                    xmlNode.Attributes.RemoveAll();
                }
                xmlDoc.Save(xmlFileName); //保存到XML文档
                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw ex; //这里可以定义你自己的异常处理
            }
            return isSuccess;
        }
        #endregion

        XmlDocument xmlDoc;
        ///<summary>
        /// 插入节点
        ///</summary>
        public void InsertNode()
        {
            xmlDoc = new XmlDocument();
            xmlDoc.Load(@"D:\Github\CSharpTest\FileTest\FileTest\bookshop.xml"); //加载xml文件

            /*从指定的字符创加载xml文件 例如：
            xmlDoc.LoadXml("(<Book bookID='B001'><BookName>jeff</BookName><price>45.6</price></Book>)");
            */
            XmlNode root = xmlDoc.SelectSingleNode("bookshop");//查找﹤bookstore﹥ 
            XmlElement xe1 = xmlDoc.CreateElement("book");//创建一个﹤book﹥节点 
            xe1.SetAttribute("genre", "Sky_Kwolf");//设置该节点genre属性 
            xe1.SetAttribute("ISBN", "2-3631-4");//设置该节点ISBN属性 

            XmlElement xesub1 = xmlDoc.CreateElement("title");
            xesub1.InnerText = "CSS禅意花园";//设置节点的文本值 
            xe1.AppendChild(xesub1);//添加到﹤book﹥节点中 
            XmlElement xesub2 = xmlDoc.CreateElement("author");
            xesub2.InnerText = "Jeff";
            xe1.AppendChild(xesub2);
            XmlElement xesub3 = xmlDoc.CreateElement("price");
            xesub3.InnerText = "58.3";
            xe1.AppendChild(xesub3);

            root.AppendChild(xe1);//添加到﹤bookshop﹥节点中 
            xmlDoc.Save(@"D:\Github\CSharpTest\FileTest\FileTest\bookshop.xml"); //保存其更改
        }
        ///<summary>
        /// 修改节点
        ///</summary>
        public void UpdateNode()
        {
            xmlDoc = new XmlDocument();
            xmlDoc.Load(@"D:\Github\CSharpTest\FileTest\FileTest\bookshop.xml"); //加载xml文件
            //获取bookshop节点的所有子节点 
            XmlNodeList nodeList = xmlDoc.SelectSingleNode("bookshop").ChildNodes;

            //遍历所有子节点 
            foreach (XmlNode xn in nodeList)
            {
                XmlElement xe = (XmlElement)xn; //将子节点类型转换为XmlElement类型 

                if (xe.GetAttribute("genre") == "Sky_Kwolf")//如果genre属性值为“Sky_Kwolf” 
                {
                    xe.SetAttribute("genre", "update Sky_Kwolf"); //则修改该属性为“update Sky_Kwolf” 
                    XmlNodeList nls = xe.ChildNodes;//继续获取xe子节点的所有子节点 

                    foreach (XmlNode xn1 in nls)//遍历 
                    {
                        XmlElement xe2 = (XmlElement)xn1; //转换类型
                        if (xe2.Name == "author")//如果找到 
                        {
                            xe2.InnerText = "jason";//则修改 
                            break;//找到退出 
                        }
                    }
                    break;
                }
            }

            xmlDoc.Save(@"D:\Github\CSharpTest\FileTest\FileTest\bookshop.xml");//保存。 
        }
        //显示xml数据
        public void ShowXml()
        {
            xmlDoc = new XmlDocument();
            xmlDoc.Load(@"D:\Github\CSharpTest\FileTest\FileTest\bookshop.xml"); //加载xml文件
            XmlNode xn = xmlDoc.SelectSingleNode("bookshop");

            XmlNodeList xnl = xn.ChildNodes;

            foreach (XmlNode xnf in xnl)
            {
                XmlElement xe = (XmlElement)xnf;
                Console.WriteLine(xe.GetAttribute("genre"));//显示属性值 
                Console.WriteLine(xe.GetAttribute("ISBN"));

                XmlNodeList xnf1 = xe.ChildNodes;
                foreach (XmlNode xn2 in xnf1)
                {
                    Console.WriteLine(xn2.InnerText);//显示子节点点文本 
                }
            }
        }
        ///<summary>
        /// 删除节点
        ///</summary>
        public void DeleteNode()
        {
            xmlDoc = new XmlDocument();
            xmlDoc.Load(@"D:\Github\CSharpTest\FileTest\FileTest\bookshop.xml"); //加载xml文件
            XmlNodeList xnl = xmlDoc.SelectSingleNode("bookshop").ChildNodes;

            foreach (XmlNode xn in xnl)
            {
                XmlElement xe = (XmlElement)xn;

                if (xe.GetAttribute("genre") == "fantasy")
                {
                    //xe.RemoveAttribute("genre");//删除genre属性 
                    xe.RemoveChild(xe.LastChild);
                    xe.RemoveChild(xe.FirstChild);
                }
                else if (xe.GetAttribute("genre") == "update Sky_Kwolf")
                {
                    xe.RemoveAll();//删除该节点的全部内容 
                }
            }
            xmlDoc.Save(@"D:\Github\CSharpTest\FileTest\FileTest\bookshop.xml");
        }
    }
}
