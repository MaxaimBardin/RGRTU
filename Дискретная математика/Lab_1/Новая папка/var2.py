def convert_matrix_representation():
    # Read the type of the original graph from the console.
    graph_type = input("Enter the type of the graph (undirected, directed, or mixed): ")
    
    # Read the original matrix representation of the graph from the console.
    n = int(input("Enter the number of vertices in the graph: "))
    print("Enter the matrix representation of the graph:")
    original_matrix = []
    for i in range(n):
        row = input().split()
        original_matrix.append([int(x) for x in row])

    # Check if the original matrix representation is valid.
    if graph_type == "undirected":
        for i in range(n):
            for j in range(i):
                if original_matrix[i][j] != original_matrix[j][i]:
                    print("Error: invalid matrix representation for an undirected graph.")
                    return
    elif graph_type == "mixed":
        for i in range(n):
            for j in range(n):
                if i == j and original_matrix[i][j] != 0:
                    print("Error: invalid matrix representation for a mixed graph.")
                    return
    # Convert the original matrix representation to the desired type.
    if graph_type == "undirected":
        converted_matrix = [[max(original_matrix[i][j], original_matrix[j][i]) for j in range(n)] for i in range(n)]
    elif graph_type == "directed":
        converted_matrix = [[max(original_matrix[i][j], original_matrix[j][i]) for j in range(n)] for i in range(n)]
    elif graph_type == "mixed":
        converted_matrix = [[original_matrix[i][j] for j in range(n)] for i in range(n)]

    # Print the converted matrix representation of the graph to the console.
    print("The converted matrix representation of the graph is:")
    for row in converted_matrix:
        print(" ".join(str(x) for x in row))

# Test the function.
convert_matrix_representation()
