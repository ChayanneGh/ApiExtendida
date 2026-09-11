document.addEventListener("DOMContentLoaded", () => {
    cargarEstudiantes();
});

async function cargarEstudiantes() {
    const contenedorTabla = document.getElementById("tabla");

    try {
        // Reemplaza /api/Estudiantes por la ruta real de tu EstudiantesController
        // Dentro de tu archivo js/estudiantes.js
        const response = await fetch('/api/estudiantes');
        if (!response.ok) throw new Error("Error al obtener los datos");

        const estudiantes = await response.json();

        if (estudiantes.length === 0) {
            contenedorTabla.innerHTML = "<h2>No hay estudiantes registrados.</h2>";
            return;
        }

        // Generación de la estructura de la tabla
        let html = `
            <table>
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Nombre</th>
                        <th>Apellido</th>
                        <th>Teléfono</th>
                        <th>ID Dirección</th>
                    </tr>
                </thead>
                <tbody>
        `;

        estudiantes.forEach(estudiante => {
            html += `
                <tr>
                    <td>${estudiante.iD_Estudiante || estudiante.id_Estudiante}</td>
                    <td>${estudiante.nombre}</td>
                    <td>${estudiante.apellido}</td>
                    <td>${estudiante.telefono}</td>
                    <td>${estudiante.iD_Direccion || estudiante.id_Direccion}</td>
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
        contenedorTabla.innerHTML = "<h2>Error al cargar el listado de estudiantes.</h2>";
    }
}
