function setupClipboardWithTooltips(buttonSelector = ".copy-btn") {
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

    btn.setAttribute("data-bs-original-title", "Copied!");
    tooltip.show();

    setTimeout(() => {
      btn.setAttribute("data-bs-original-title", "Copy to clipboard");
      tooltip.hide();
    }, 2000);

    e.clearSelection();
  });

  clipboard.on("error", function (e) {
    const btn = e.trigger;
    const tooltip = bootstrap.Tooltip.getInstance(btn);

    btn.setAttribute("data-bs-original-title", "Failed to copy");
    tooltip.show();

    setTimeout(() => {
      btn.setAttribute("data-bs-original-title", "Copy to clipboard");
      tooltip.hide();
    }, 2000);
  });
}
