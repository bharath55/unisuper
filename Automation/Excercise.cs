using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;

namespace Automation
{
    class Excercise
    {
        IWebDriver driver;
        IWebElement angularjsElement;
        IWebElement newTodoElement;
        IWebElement editTodoElement;
        IWebElement parentTodoElement;
        IWebElement childCompleteTodoElement;
        IWebElement goTodoElement;
        IWebElement parentClearSingleTodoElement;
        IWebElement childClearSingleTodoElement;
        IWebElement toggleAllTodoElement;
        IWebElement completedElement;
        IWebElement clearAllElement;

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void OpenTodoMVC()
        {
            driver.Navigate().GoToUrl("http://todomvc.com");

            angularjsElement = driver.FindElement(By.LinkText("AngularJS"));
            angularjsElement.Click();

            System.Threading.Thread.Sleep(1000);

            newTodoElement = driver.FindElement(By.Id("new-todo"));
            newTodoElement.Click();
            newTodoElement.SendKeys("To-do");
            newTodoElement.SendKeys(Keys.Return);

            /*
            editTodoElement = driver.FindElement(By.ClassName("ng-binding"));
            Actions action = new Actions(driver);
            action.DoubleClick(editTodoElement).Perform();

            editTodoElement.SendKeys("Edited");
            editTodoElement.SendKeys(Keys.Return);
            */

            parentTodoElement = driver.FindElement(By.ClassName("view"));
            childCompleteTodoElement = parentTodoElement.FindElement(By.TagName("input"));
            childCompleteTodoElement.Click();

            childCompleteTodoElement.Click();

            newTodoElement.Click();
            newTodoElement.SendKeys("Second To-do");
            newTodoElement.SendKeys(Keys.Return);

            toggleAllTodoElement = driver.FindElement(By.Id("toggle-all"));
            toggleAllTodoElement.Click();

            newTodoElement.Click();
            newTodoElement.SendKeys("Third To-do");
            newTodoElement.SendKeys(Keys.Return);

            completedElement = driver.FindElement(By.LinkText("Completed"));
            completedElement.Click();
            
            goTodoElement = driver.FindElement(By.ClassName("ng-binding"));
            goTodoElement.Click();
            parentClearSingleTodoElement = driver.FindElement(By.ClassName("view"));
            childClearSingleTodoElement = parentClearSingleTodoElement.FindElement(By.TagName("button"));
            childClearSingleTodoElement.Click();

            clearAllElement = driver.FindElement(By.Id("clear-completed"));
            clearAllElement.Click();

        }

        [TearDown]
        public void EndTest()
        {
            driver.Close();
        }
    }
}
