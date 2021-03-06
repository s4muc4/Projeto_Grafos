﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGrafos.DataStructure
{
    /// <summary>
    /// Classe que representa um grafo.
    /// </summary>
    public class Graph
    {

        #region Atributos

        /// <summary>
        /// Lista de nós que compõe o grafo.
        /// </summary>
        private List<Node> nodes;

        #endregion

        #region Propridades

        /// <summary>
        /// Mostra todos os nós do grafo.
        /// </summary>
        public Node[] Nodes
        {
            get { return this.nodes.ToArray(); }
        }

        #endregion

        #region Construtores

        /// <summary>
        /// Cria nova instância do grafo.
        /// </summary>
        public Graph()
        {
            this.nodes = new List<Node>();
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Encontra o nó através do seu nome.
        /// </summary>
        /// <param name="name">O nome do nó.</param>
        /// <returns>O nó encontrado ou nulo caso não encontre nada.</returns>
        private Node Find(string name)
        {
            if (nodes.Count != 0)
                foreach( Node item in nodes)
                {
                    if (name.Equals(item.Name))
                    {
                        
                        return item;
                    }
                        
                }
            return null;
        }

        /// <summary>
        /// Adiciona um nó ao grafo.
        /// </summary>
        /// <param name="name">O nome do nó a ser adicionado.</param>
        /// <param name="info">A informação a ser armazenada no nó.</param>
        public void AddNode(string name)
        {
            Node n = new Node(name, null);
            

            if (Find(name) == null)
            {
                Console.WriteLine("adicionando no: " + n);
                nodes.Add(n);    
            }
                

        }
        /// <summary>>
        /// Adiciona um nó ao grafo.
        /// </summary>
        /// <param name="name">O nome do nó a ser adicionado.</param>
        /// <param name="info">A informação a ser armazenada no nó.</param>
        public void AddNode(string name, object info)
        {
            Node n = new Node(name, info);
            n = Find(name);

            if (n == null)
                nodes.Add(n);
        }

        /// <summary>
        /// Remove um nó do grafo.
        /// </summary>
        /// <param name="name">O nome do nó a ser removido.</param>
        public void RemoveNode(string name)
        {
            Node n = Find(name);

            Console.WriteLine("nó para remover: " + n);

            if ( n!= null)
            {
                foreach (var node in nodes)
                {
                    Edge [] edgeAux = node.Edges.ToArray();
                    foreach (var edge in edgeAux)
                    {
                        if(edge.To==n)
                        {
                            node.Edges.Remove(edge);
                        }
                    }
                }
                nodes.Remove(n);
            }
        }

        /// <summary>
        /// Adiciona o arco entre dois nós associando determinado custo.
        /// </summary>
        /// <param name="from">O nó de origem.</param>
        /// <param name="to">O nó de destino.</param>
        /// <param name="cost">O cust associado.</param>
        public void AddEdge(string from, string to, double cost)
        {
            Node de = Find(from);
            Node para = Find(to);

            if(de!=null && para!=null)
                de.AddEdge(para,cost);  
        }

        /// <summary>
        /// Obtem todos os nós vizinhos de determinado nó.
        /// </summary>
        /// <param name="node">O nó origem.</param>
        /// <returns></returns>
        public Node[] GetNeighbours(string from)
        {
            Node no = Find(from);
            int qtde = no.Edges.Count;
            int i = 0;
            bool achou = false;
            Node[] vizinhos = new Node [qtde];
           
            Console.WriteLine(qtde);

            foreach (var item in no.Edges)
            {
                Console.WriteLine(item.To.ToString());
                vizinhos[i++] = item.To;
                achou = true;
            }
            if (achou = true)
                return vizinhos;


           

            return null;
        }

        /// <summary>
        /// Valida um caminho, retornando a lista de nós pelos quais ele passou.
        /// </summary>
        /// <param name="nodes">A lista de nós por onde passou.</param>
        /// <param name="path">O nome de cada nó na ordem que devem ser encontrados.</param>
        /// <returns></returns>
        public bool IsValidPath(ref Node[] nodes, params string[] path)
        {
            return false;
        }

        #endregion

    }
}
