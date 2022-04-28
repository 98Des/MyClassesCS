﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developing.Graphs
{
    internal class Graph : IGraph
    {
        protected DirectedGraph _diGraph;

        /// <inheritdoc/>
        public bool Directed => false;

        /// <inheritdoc/>
        public int VertexCount => _diGraph.VertexCount;

        /// <inheritdoc/>
        public IGraphRepresentation Representation => _diGraph.Representation;

        public Graph(int vertices, IGraphRepresentation representation) =>
            _diGraph = new DirectedGraph(vertices, representation);

        public Graph(int vertices) => _diGraph = new DirectedGraph(vertices);

        public bool AddEdge(int u, int v) => _diGraph.AddEdge(u, v) && _diGraph.AddEdge(v, u);
        public bool RemoveEdge(int u, int v) => _diGraph.RemoveEdge(u, v) && _diGraph.RemoveEdge(v, u);

        /// <inheritdoc/>
        public bool HasEdge(int from, int to) => _diGraph.HasEdge(from, to);

        /// <inheritdoc/>
        public IEnumerable<int> OutNeighbors(int v) => _diGraph.OutNeighbors(v);

        /// <inheritdoc />
        public override string ToString() => _diGraph.ToString();
    }
}
