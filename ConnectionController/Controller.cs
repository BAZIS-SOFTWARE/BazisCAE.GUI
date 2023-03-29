using LicenseData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ConnectionController
{
    public class Controller
    {
        public string[] InfoLocakKey(string keyPath)
        {
            if (!(File.Exists(keyPath)))
                throw new Exception("Не найден файл лицензии!");
            else
            {
                var keyManager = new LicenseManager();
                var licInfo = keyManager.Load(keyPath);

                var info = new List<string>();

                foreach (var keyInfo in licInfo)
                    info.Add(keyInfo.ToString());

                info.Insert(0,licInfo.CompanyName);

                return info.ToArray();
            }
        }  

        public void RequestServer(LicenseToken token)
        {
            var tcpClient = new TcpClient();

            tcpClient.Connect(token.IPAddress, token.Port);

            // получаем NetworkStream для взаимодействия с сервером
            var stream = tcpClient.GetStream();

            // буфер для входящих данных
            var response = new List<byte>();
  
            int bytesRead = 10; // для считывания байтов из потока

            // считыванием строку в массив байт
            // при отправке добавляем маркер завершения сообщения - \n
            byte[] data = Encoding.UTF8.GetBytes(token.Request + '\n');
            // отправляем данные
            stream.Write(data, 0, data.Length);

            // считываем данные до конечного символа
            while ((bytesRead = stream.ReadByte()) != '\n')
            {
                // добавляем в буфер
                response.Add((byte)bytesRead);
            }
            var answer = Encoding.UTF8.GetString(response.ToArray());
            response.Clear();

            // отправляем маркер завершения подключения - END
            var finish = Encoding.UTF8.GetBytes("END\n");
            stream.Write(finish, 0, finish.Length);

            token.Answer = answer ;
        }
    }
}
