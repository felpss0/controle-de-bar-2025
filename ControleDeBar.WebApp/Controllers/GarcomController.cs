﻿using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Infraestrura.Arquivos.Compartilhado;
using ControleDeBar.Infraestrura.Arquivos.ModuloMesa;
using ControleDeBar.WebApp.Extensions;
using ControleDeBar.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;

namespace ControleDeBar.WebApp.Controllers
{
    [Route("garcons")]
    public class GarcomController : Controller
    {
        private readonly ContextoDados contextoDados;
        private readonly IRepositorioGarcom repositorioGarcom;

        public GarcomController()
        {
            contextoDados = new ContextoDados(true);
            repositorioGarcom = new RepositorioGarcomEmArquivo(contextoDados);
        }

        public IActionResult Index()
        {
            var registros = repositorioGarcom.SelecionarRegistros();

            var visualizarVM = new VisualizarGarconsViewModel(registros);

            return View(visualizarVM);
        }

        [HttpGet("cadastrar")]
        public IActionResult Cadastrar()
        {
            var cadastrarVM = new CadastrarGarcomViewModel();

            return View(cadastrarVM);
        }

        [HttpPost("cadastrar")]
        public ActionResult Cadastrar(CadastrarGarcomViewModel cadastrarVM)
        {
            var registros = repositorioGarcom.SelecionarRegistros();

            foreach (var item in registros)
            {
                if (item.Cpf == cadastrarVM.Cpf) 
                {
                    ModelState.AddModelError("CadastroUnico", "Já existe um garçom com este CPF.");
                    break;
                }
            }

            if (!ModelState.IsValid) 
                return View(cadastrarVM);
            

            var entidade = cadastrarVM.ParaEntidade();

            repositorioGarcom.CadastrarRegistro(entidade);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("editar/{id:guid}")]
        public ActionResult Editar(Guid id)
        {
            var registroSelecionado = repositorioGarcom.SelecionarRegistroPorId(id);

            var editarVM = new EditarGarcomViewModel(
                id,
                registroSelecionado.Nome,
                registroSelecionado.Cpf
            );

            return View(editarVM);
        }

        [HttpPost("editar/{id:guid}")]
        public ActionResult Editar(Guid id, EditarGarcomViewModel editarVM)
        {
            var registros = repositorioGarcom.SelecionarRegistros();

            foreach (var item in registros)
            {
                if (item.Cpf == editarVM.Cpf)
                {
                    ModelState.AddModelError("CadastroUnico", "Já existe um garçom com este CPF.");
                    break;
                }
            }

            if (!ModelState.IsValid)
                return View(editarVM);

            var entidadeEditada = editarVM.ParaEntidade();

            repositorioGarcom.EditarRegistro(id, entidadeEditada);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("excluir/{id:guid}")]
        public ActionResult Excluir(Guid id)
        {
            var registroSelecionado = repositorioGarcom.SelecionarRegistroPorId(id);

            var excluirVM = new ExcluirGarcomViewModel(registroSelecionado.Id, registroSelecionado.Nome);

            return View(excluirVM);
        }

        [HttpPost("excluir/{id:guid}")]
        public ActionResult ExcluirConfirmado(Guid id)
        {
            repositorioGarcom.ExcluirRegistro(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("detalhes/{id:guid}")]
        public ActionResult Detalhes(Guid id)
        {
            var registroSelecionado = repositorioGarcom.SelecionarRegistroPorId(id);

            var detalhesVM = new DetalhesGarcomViewModel(
                id,
                registroSelecionado.Nome,
                registroSelecionado.Cpf
            );

            return View(detalhesVM);
        }
    }
}
