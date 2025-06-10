function setupClipboardWithTooltips(buttonSelector, successText, errorText) {
    // Initialize Bootstrap tooltips manually
    const buttons = document.querySelectorAll(buttonSelector);
    buttons.forEach((btn) => {
        new bootstrap.Tooltip(btn, { trigger: "manual" });
    });

    // Initialize Clipboard.js
    const clipboard = new ClipboardJS(buttonSelector);

    clipboard.on("success", function (e) {
        const btn = e.trigger;
        const tooltip = bootstrap.Tooltip.getInstance(btn);

        btn.setAttribute("data-bs-original-title", successText);
        tooltip.show();

        setTimeout(() => {
            tooltip.hide();
        }, 1500);

        e.clearSelection();
    });

    clipboard.on("error", function (e) {
        const btn = e.trigger;
        const tooltip = bootstrap.Tooltip.getInstance(btn);

        btn.setAttribute("data-bs-original-title", errorText);
        tooltip.show();

        setTimeout(() => {
            tooltip.hide();
        }, 1500);
    });
}
