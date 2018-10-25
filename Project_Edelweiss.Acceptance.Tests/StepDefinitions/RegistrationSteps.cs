using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Project_Edelweiss.Acceptance.Tests.StepDefinitions
{
    [Binding]
    public class RegistrationSteps
    {
        private BasicsSteps basicsSteps;

        public RegistrationSteps(BasicsSteps basicsSteps)
        {
            this.basicsSteps = basicsSteps;
        }

        [Given(@"я нахожусь на странице регистрации")]//авторизации
        public void ДопустимЯНахожусьНаСтраницеРегистрации()
        {
            basicsSteps.GoToMainPage();
            basicsSteps.ClickLink("Register");
            //basicsSteps.ClickLink("Log in");
        }

      
        //[When(@"я авторизуюсь как администратор")]
        [When(@"я регистрируюсь как администратор")]//я авторизуюсь как пользователь системы
        public void WhenЯРегистрируюсьКакАдминистратор()
        {
            basicsSteps.FillTextNearLabel("Email", "email@site.com", "email");
            basicsSteps.FillTextNearLabel("Password", "123456", "password");
            //basicsSteps.FillTextNearLabel("Confirm password", "123456", "password");
            //basicsSteps.SelectElement("AgentId", "Агент 1");
            //basicsSteps.ClickButton("Register");
            basicsSteps.ClickButton("Log in");
        }
        
        [Then(@"я вижу главную страницу")]
        public void ТоЯВижуГлавнуюСтраницу()
        {
            Assert.True(basicsSteps.IsElementFound("Index"));
        }
    }
}
