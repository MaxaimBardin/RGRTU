def incidence_to_adjacency(incidence_matrix: list) -> list:

    n_vertices = len(incidence_matrix[0])
    n_edges = len(incidence_matrix)

    adjacency_matrix = [[0] * n_vertices for i in range(n_vertices)]

    directed = False
    for i in range(n_edges):
        if incidence_matrix[i].count(1) > 1:
            directed = True
            break

    for i in range(n_edges):
        indices = [j for j, x in enumerate(incidence_matrix[i]) if x == 1]
        if directed:
            adjacency_matrix[indices[0]][indices[1]] = 1
        else:
            for j in range(len(indices)):
                for k in range(j+1, len(indices)):
                    adjacency_matrix[indices[j]][indices[k]] = 1
                    adjacency_matrix[indices[k]][indices[j]] = 1

    return adjacency_matrix

from incidence_adjacency import incidence_to_adjacency

incidence_matrix = [
    [1, 1, 0, 0],
    [0, 1, 1, 0],
    [0, 0, 1, 1],
    [1, 0, 1, 0]
]

adjacency_matrix = incidence_to_adjacency(incidence_matrix)

print(adjacency_matrix)