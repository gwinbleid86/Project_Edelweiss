using System;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Project_Edelweiss.Acceptance.Tests.StepDefinitions
{
    [Binding]
    public class RegistrationClientFeatureSteps
    {
        private IWebDriver driver;
        private const string MAIN_PAGE_URL = "http://localhost:56257/";

        private BasicsSteps basicsSteps;
        public RegistrationClientFeatureSteps(BasicsSteps basicsSteps)
        {
            this.basicsSteps = basicsSteps;
        }
        [Given(@"Я в роли пользователя системы нахожусь на  странице регистрации клиента")]
        public void GivenЯВРолиПользователяСистемыНахожусьНаСтраницеРегистрацииКлиента()
        {
            basicsSteps.GoToMainPage();
            basicsSteps.FillText("userName", "login");
            basicsSteps.FillText("password", "123456");
            basicsSteps.ClickButton("Log in");
            basicsSteps.ClickLink("Поиск клиентов");
            basicsSteps.FillText("passp", "B7");
            basicsSteps.ClickButtonT("search");
        }
        
        [When(@"Я заполняю регистрационные данные клиента")]
        public void WhenЯЗаполняюРегистрационныеДанныеКлиента()
        {
            basicsSteps.FillText("Name", "Client111");
            basicsSteps.FillText("LastName", "Clienov");
            basicsSteps.FillText("MobilePhone", "102800");
            basicsSteps.FillText("PassportData", "B7");
            basicsSteps.ClickButton("Регистрация клиента");
        }

        [Then(@"Я вижу страницу поиска клиента")]
        public void ThenЯВижуСтраницуПоискаКлиента()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
