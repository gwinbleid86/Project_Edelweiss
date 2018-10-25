using System;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Project_Edelweiss.Acceptance.Tests.StepDefinitions
{
    [Binding]
    public class AuthorizationFeature1Steps
    {
        private IWebDriver driver;
        private const string MAIN_PAGE_URL = "http://localhost:56257/";

        private BasicsSteps basicsSteps;

        public AuthorizationFeature1Steps(BasicsSteps basicsSteps)
        {
            this.basicsSteps = basicsSteps;
        }
        [Given(@"Я нахожусь на странице авторизации в приложении")]
        public void GivenЯНахожусьНаСтраницеАвторизацииВПриложении()
        {
            basicsSteps.GoToMainPage();
        }
        
        [When(@"Я ввожу логин и пароль, и нажимаю ""(.*)""")]
        public void WhenЯВвожуЛогинИПарольИНажимаю(string p0)
        {
            basicsSteps.FillText("userName", "login");
            basicsSteps.FillText("password", "123456");
            basicsSteps.ClickButton("Log in");
        }
        
        [Then(@"Я вижу главную страницу приложения")]
        public void ThenЯВижуГлавнуюСтраницуПриложения()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
