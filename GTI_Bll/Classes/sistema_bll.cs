﻿using GTI_Dal.Classes;
using GTI_Models.Models;
using System;
using System.Collections.Generic;

namespace GTI_Bll.Classes {
    public class Sistema_bll {

        private string _connection;
        public Sistema_bll(string sConnection) {
            _connection = sConnection;
        }

        /// <summary>Retorna o nome completo do usuário pelo login.
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public string Retorna_User_FullName(string loginName) {
            Sistema_Data obj = new Sistema_Data(_connection);
            return obj.Retorna_User_FullName(loginName);
        }


        /// <summary>Retorna o login do usuário pelo nome completo.
        /// </summary>
        /// <param name="fullName"></param>
        /// <returns></returns>
        public string Retorna_User_LoginName(string fullName) {
            Sistema_Data obj = new Sistema_Data(_connection);
            return obj.Retorna_User_LoginName(fullName);
        }

        /// <summary>Retorna o Id do usuário pelo login.
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public int Retorna_User_LoginId(string loginName) {
            Sistema_Data obj = new Sistema_Data(_connection);
            return obj.Retorna_User_LoginId(loginName);
        }

        /// <summary>Retorna o login do usuário pelo Id.
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        public string Retorna_User_LoginName(int idUser) {
            Sistema_Data obj = new Sistema_Data(_connection);
            return obj.Retorna_User_LoginName(idUser);
        }

        /// <summary>Retorna a senha do usuário.
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public string Retorna_User_Password(string login) {
            Sistema_Data obj = new Sistema_Data(_connection);
            return obj.Retorna_User_Password(login);
        }

        /// <summary>Retorna os dados principais do contribuinte.
        /// </summary>
        public Contribuinte_Header_Struct Contribuinte_Header(int Codigo) {
            dalCore.LocalEndereco Tipo;
            Sistema_Data obj = new Sistema_Data(_connection);
            if (Codigo < 100000)
                Tipo = dalCore.LocalEndereco.Imovel;
            else if (Codigo >= 100000 && Codigo < 500000)
                Tipo = dalCore.LocalEndereco.Empresa;
            else
                Tipo = dalCore.LocalEndereco.Cidadao;

            return obj.Contribuinte_Header(Codigo, Tipo);
        }

        /// <summary>Verifica se o código fornacido esta cadastrado no sistema
        /// </summary>
        public bool Existe_Cadastro(int Codigo) {
            bool bRet = false;
            if (Codigo < 100000) {
                Imovel_bll clsImovel = new Imovel_bll(_connection);
                if (clsImovel.Existe_Imovel(Codigo))
                   bRet = true;
            } else if(Codigo>=100000 && Codigo<300000) {
                Empresa_bll clsEmpresa = new Empresa_bll(_connection);
                if (clsEmpresa.Existe_Empresa(Codigo))
                    bRet = true;
            } else {
                Cidadao_bll clsCidadao = new Cidadao_bll(_connection);
                if (clsCidadao.ExisteCidadao(Codigo))
                    bRet = true;
            }
            return bRet;
        }

        /// <summary>Alterar a senha de um usuário
        /// </summary>
        public Exception Alterar_Senha(Usuario reg) {
            Sistema_Data obj = new Sistema_Data(_connection);
            Exception ex = obj.Alterar_Senha(reg);
            return ex;
        }

        /// <summary>Alterar o acesso binário de um usuário
        /// </summary>
        public Exception SaveUserBinary(Usuario reg) {
            Sistema_Data obj = new Sistema_Data(_connection);
            Exception ex = obj.SaveUserBinary(reg);
            return ex;
        }

        /// <summary>Retorna a lista dos eventos de segurança do sistema
        /// </summary>
        public List<security_event> Lista_Sec_Eventos() {
            Sistema_Data obj = new Sistema_Data(_connection);
            return obj.Lista_Sec_Eventos();
        }

        /// <summary>Retorna o último código cadastrado da tabela usuário
        /// </summary>
        public int? Retorna_Ultimo_Codigo_Usuario() {
            Sistema_Data obj = new Sistema_Data(_connection);
            return obj.Retorna_Ultimo_Codigo_Usuario();
        }

        /// <summary>Incluir novo usuário
        /// </summary>
        public Exception Incluir_Usuario(Usuario reg) {
            Sistema_Data obj = new Sistema_Data(_connection);
            return obj.Incluir_Usuario(reg);
        }

        /// <summary>Alterar o usuário selecionado
        /// </summary>
        public Exception Alterar_Usuario(Usuario reg) {
            Sistema_Data obj = new Sistema_Data(_connection);
            return obj.Alterar_Usuario(reg);
        }

        /// <summary>Retorna os dados do usuário selecionado
        /// </summary>
        public usuarioStruct Retorna_Usuario(int Id) {
            Sistema_Data obj = new Sistema_Data(_connection);
            return obj.Retorna_Usuario(Id);
        }


        /// <summary>Retorna a lista de todos os usuários cadastrados
        /// </summary>
        public List<usuarioStruct> Lista_Usuarios() {
            Sistema_Data obj = new Sistema_Data(_connection);
            return obj.Lista_Usuarios();
        }

        /// <summary>Retorna a lista dos centro de custos de um usuário
        /// </summary>
        public List<Usuariocc> Lista_Usuario_Local(int Id) {
            Sistema_Data obj = new Sistema_Data(_connection);
            return obj.Lista_Usuario_Local(Id);
        }

        /// <summary>Grava o acesso aos centros de custo de um usuário
        /// </summary>
        public Exception Alterar_Usuario_Local(List<Usuariocc> reg) {
            Sistema_Data obj = new Sistema_Data(_connection);
            return obj.Alterar_Usuario_Local(reg);
        }

        /// <summary>return the size of the binary string access
        /// </summary>
        public int GetSizeofBinary() {
            Sistema_Data obj = new Sistema_Data(_connection);
            return obj.GetSizeofBinary();
        }

        /// <summary>Retorna a binary string do usuário.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetUserBinary(int id) {
            Sistema_Data obj = new Sistema_Data(_connection);
            return obj.GetUserBinary(id);
        }


    }
}
