async function fetchProducts() {
    try {
        const response = await fetch('/api/products');
        if (!response.ok) throw new Error("Failed to fetch products");
        const products = await response.json();
        displayProducts(products);
    } catch (error) {
        console.error("Error loading products:", error);
    }
}

function displayProducts(products) {
    const productContainer = document.getElementById("productList");
    products.forEach(product => {
        const productElement = document.createElement("div");
        productElement.innerHTML = `<h3>${product.productName}</h3><p>${product.description}</p><p>Price: ${product.price}</p>`;
        productContainer.appendChild(productElement);
    });
}
