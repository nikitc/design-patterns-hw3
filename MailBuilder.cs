using System.Collections.Generic;

namespace Patterns3
{
    public class MailBuilder
    {
        public MailRecBuilder AddRecepient(string recepient)
        {
            return new MailRecBuilder(recepient);
        }

        public class MailRecBuilder
        {
            private readonly List<string> _recepients = new List<string>();

            public MailRecBuilder(string recepient)
            {
                _recepients.Add(recepient);

            }

            public MailBodyBuilder AddBody(string body)
            {
                return new MailBodyBuilder(_recepients, body);
            }

            public MailRecBuilder AddRecepient(string recepient)
            {
                return new MailRecBuilder(recepient);
            }

        }

        public class MailBodyBuilder
        {
            private readonly List<string> _recepients;
            private readonly string _body = "";

            public MailBodyBuilder(List<string> recepients, string body)
            {
                _recepients = recepients;
                _body += body;
            }

            public MailBodyBuilder AddRecepient(string recepient)
            {
                _recepients.Add(recepient);
                return new MailBodyBuilder(_recepients, _body);
            }

            public FinalMailBuilder AddTheme(string theme)
            {
                return new FinalMailBuilder(theme, _recepients, _body);
            }

            public string Build => $"Получатели: {string.Join(" ", _recepients)} \r\n " +
                                   $"Текст письма: {_body}";
        }

        public class FinalMailBuilder
        {
            private readonly List<string> _recepients;
            private readonly string _body = "";
            private readonly string _theme;
            public FinalMailBuilder(string theme, List<string> recepients, string body)
            {
                _theme = theme;
                _recepients = recepients;
                _body += body;
            }

            public FinalMailBuilder AddRecepient(string recepient)
            {
                _recepients.Add(recepient);
                return new FinalMailBuilder(_theme, _recepients, _body);
            }

            public string Build =>
                $"Получатели: {string.Join(" ", _recepients)} \r\n " +
                $"Тема: {_theme} \r\n  " +
                $"Текст письма: {_body}";
        }


    }
}