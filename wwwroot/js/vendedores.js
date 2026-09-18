document.addEventListener("DOMContentLoaded", () => {
    cargarVendedores();
});

async function cargarVendedores() {
    const contenedorTabla = document.getElementById("tabla");

    try {
        const response = await fetch('/api/vendedores');
        if (!response.ok) throw new Error("Error al obtener los datos");

        const vendedores = await response.json();

        if (vendedores.length === 0) {
            contenedorTabla.innerHTML = "<h2>No hay vendedores registrados.</h2>";
            return;
        }

        // Generación de la estructura de la tabla con todas las columnas de Vendedor
        let html = `
            <table>
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Nombre</th>
                        <th>Apellido</th>
                        <th>Teléfono</th>
                        <th>Reputación</th>
                        <th>Fecha de Inicio</th>
                        <th>ID Dirección</th>
                    </tr>
                </thead>
                <tbody>
        `;

        vendedores.forEach(vendedor => {
            // Convertimos la fecha a un formato local legible (DD/MM/AAAA)
            const fechaFormateada = vendedor.fechaInicio 
                ? new Date(vendedor.fechaInicio).toLocaleDateString() 
                : 'N/A';

            html += `
                <tr>
                    <td>${vendedor.id}</td> <!-- ¡Corregido! En JS llega como 'id' -->
                    <td>${vendedor.nombre}</td>
                    <td>${vendedor.apellido}</td>
                    <td>${vendedor.telefono}</td>
                    <td>${vendedor.reputacion}</td>
                    <td>${fechaFormateada}</td>
                    <td>${vendedor.iD_Direccion || vendedor.id_Direccion}</td>
                </tr>
            `;
        });

        html += `
                </tbody>
            </table>
        `;

        contenedorTabla.innerHTML = html;

    } catch (error) {
        console.error("Error:", error);
        contenedorTabla.innerHTML = "<h2>Error al cargar el listado de vendedores.</h2>";
    }
}
