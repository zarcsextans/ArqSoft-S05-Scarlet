async function calcular(op) {
    const a = document.getElementById("a").value;
    const b = document.getElementById("b").value;

    try {
        const res = await fetch(
            `https://localhost:7219/api/calculadora/${op}?a=${a}&b=${b}`
        );

        const data = await res.json();

        document.getElementById("resultado").innerHTML =
            "Resultado: " + data.resultado;
    }
    catch {
        document.getElementById("resultado").innerHTML =
            "❌ Error: API desconectada";
    }
}