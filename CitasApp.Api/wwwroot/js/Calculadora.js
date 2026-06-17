async function calc(op) {
    const a = document.getElementById("a").value;
    const b = document.getElementById("b").value;

    try {
        const url = "https://localhost:7219/api/calculadora/" + op +
            "?a=" + a + "&b=" + b;

        const response = await fetch(url);

        const data = await response.json();

        document.getElementById("res").innerHTML =
            "Resultado: <b>" + data.resultado + "</b>";
    }
    catch (error) {
        console.log("ERROR REAL:", error);

        document.getElementById("res").innerHTML =
            "❌ Error: API desconectada";
    }
}