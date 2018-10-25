using System;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Project_Edelweiss.Acceptance.Tests.StepDefinitions
{
    [Binding]
    public class AgentRegistrationFeature1Steps
    {
        private IWebDriver driver;
        private const string MAIN_PAGE_URL = "http://localhost:56257/";

        private BasicsSteps basicsSteps;

        public AgentRegistrationFeature1Steps(BasicsSteps basicsSteps)
        {
            this.basicsSteps = basicsSteps;
        }
        [Given(@"Я администратор системы и нахожусь на главной странице приложения")]
        public void GivenЯАдминистраторСистемыИНахожусьНаГлавнойСтраницеПриложения()
        {
            basicsSteps.GoToMainPage();
            basicsSteps.FillText("userName", "login");
            basicsSteps.FillText("password", "123456");
            basicsSteps.ClickButton("Log in");
        }
        
        [When(@"Я перехожу по ссылке ""(.*)"" и заполняю регистрационные данные")]
        public void WhenЯПерехожуПоСсылкеИЗаполняюРегистрационныеДанные(string p0)
        {
            basicsSteps.ClickLink("Агенты");
            basicsSteps.ClickLink("Создать нового");
            basicsSteps.FillTextNearLabel("Название агента", "Agent 007", "name");
            basicsSteps.ClickButtonT("createAgent");

        }
        
        [Then(@"Я вижу список зарегистрированных агентов")]
        public void ThenЯВижуСписокЗарегистрированныхАгентов()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
