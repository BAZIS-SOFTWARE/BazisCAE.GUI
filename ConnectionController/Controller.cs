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

        public void RequestLocakKey(LocalToken token)
        {
            if (!(File.Exists(token.Path)))
                throw new Exception("Не найден файл лицензии!");
            else
            {
                var licManager = new LicenseManager();

                var licInfo = licManager.Load(token.Path);

                if (token.Request == "Weld" |
                    token.Request == "HeatTreatment" |
                    token.Request == "Mesh" |
                    token.Request == "Result")
                {
                    var module = licManager.ParseModule(token.Request);
                    token.Answer = licInfo.Find(module) != null ? "можно" : "нельзя";
                }
                else if(token.Request == "ThermalSolver" |
                    token.Request == "MechanicalSolver" |
                    token.Request == "ChemicalSolver" |
                    token.Request == "HardnessSolver"
                    )
                {
                    var module = licManager.ParseModule(token.Request);
                    var keyInfo = licInfo.Find(module);
                    if (keyInfo != null)
                    {
                        if (keyInfo.Edition == Edition.Professional)
                            token.Answer = "можно 20000000";
                        else if (keyInfo.Edition == Edition.Study)
                            token.Answer = "можно 30000";
                        else token.Answer = "можно 10000";
                    }
                    else token.Answer = "нельзя";
                }

                else token.Answer = "Не зарегистрированный запрос";
            }
        }

        public void RequestServer(NetToken token)
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
