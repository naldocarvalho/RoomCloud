﻿namespace Repository.Domain
{
    public class Cliente : Base
    {
        public string nome { get; set; }
        public string email { get; set; }
        public string endereco { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }
    }
}
