// collocated with DownloadButton.razor; from the Blazor file downloads documentation
export async function downloadFileFromStream(fileName, contentStreamReference) {
  const arrayBuffer = await contentStreamReference.arrayBuffer();
  const blob = new Blob([arrayBuffer], { type: "application/pdf" });
  const url = URL.createObjectURL(blob);
  const anchorElement = document.createElement("a");
  anchorElement.href = url;
  anchorElement.download = fileName ?? "";
  anchorElement.click();
  anchorElement.remove();
  URL.revokeObjectURL(url);
}
