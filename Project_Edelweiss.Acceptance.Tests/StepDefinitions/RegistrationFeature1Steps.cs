using System;
using TechTalk.SpecFlow;

namespace Project_Edelweiss.Acceptance.Tests.StepDefinitions
{
    [Binding]
    public class RegistrationFeature1Steps
    {
        private BasicsSteps basicsSteps;

        public RegistrationFeature1Steps(BasicsSteps basicsSteps)
        {
            this.basicsSteps = basicsSteps;
        }
        [Given(@"Я, как администратор системы нахожусь на главной странице приложения")]
        public void GivenЯКакАдминистраторСистемыНахожусьНаГлавнойСтраницеПриложения()
        {
            basicsSteps.GoToMainPage();
            basicsSteps.FillText("userName", "login");
            basicsSteps.FillText("password", "123456");
            basicsSteps.ClickButton("Log in");
            basicsSteps.ClickLink("Регистрация");
        }
        
        [When(@"Я перехожу по ссылке ""(.*)"" и ввожу регистрационные данные")]
        public void WhenЯПерехожуПоСсылкеИВвожуРегистрационныеДанные(string p0)
        {
            //
            basicsSteps.FillTextNearLabel("Email", "email2@site.com", "email");
           // basicsSteps.FillText("password", "123456");
            basicsSteps.FillTextNearLabel("Password", "123456", "password");
            basicsSteps.FillTextNearLabel("ConfirmPassword", "123456", "password");
            basicsSteps.FillText("userName", "login2");
            basicsSteps.SelectElement("AgentId", "Optima");
            basicsSteps.ClickButton("Регистрация");
            //basicsSteps.ClickLinkk("AgentId", "все","Optima");
            // basicsSteps.FillTextNearLabel("Login", "login1", "login");
            //basicsSteps.FillText("password", "123456");
        }
        
        [Then(@"Я вижу данные зарегистрированного пользователя")]
        public void ThenЯВижуДанныеЗарегистрированногоПользователя()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
