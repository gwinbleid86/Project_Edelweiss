using System;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Project_Edelweiss.Acceptance.Tests.StepDefinitions
{
    [Binding]
    public class SearchClientSteps
    {
        private IWebDriver driver;
        private const string MAIN_PAGE_URL = "http://localhost:56257/";

        private BasicsSteps basicsSteps;
        public SearchClientSteps(BasicsSteps basicsSteps)
        {
            this.basicsSteps = basicsSteps;
        }

        [Given(@"Я нахожусь на главной странице приложения и я зарегистрирован\(а\) в роли ""(.*)""")]
        public void GivenЯНахожусьНаГлавнойСтраницеПриложенияИЯЗарегистрированАВРоли(string p0)
        {
            basicsSteps.GoToMainPage();
            basicsSteps.FillText("userName", "login"/*, "username"*/);
            basicsSteps.FillText("password", "123456"/*, "password"*/);
            basicsSteps.ClickButton("Log in");
        }
        
        [When(@"Я перехожу по ссылке поиск клиентов, ввожу номер паспорта")]
        public void WhenЯПерехожуПоСсылкеПоискКлиентовВвожуНомерПаспорта()
        {
            basicsSteps.ClickLink("Поиск клиентов");
            basicsSteps.FillText("passp", "AN12345");
            

        }
        
        [Then(@"И вижу список последних переводов клиента")]
        public void ThenИВижуСписокПоследнихПереводовКлиента()
        {
            basicsSteps.ClickButtonT("search");
        }
    }
}
