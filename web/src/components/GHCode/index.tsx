import React, { useEffect, useState } from "react";
import CodeBlock from "@theme/CodeBlock";

export default function GHCode({
  language,
  user = "departement-info-cem",
  repo,
  filePath,
  endLine,
  startLine = 0,
  showLineNumber = false,
  branch = "main",
}: {
  language?: string;
  user?: string;
  repo: string;
  filePath: string;
  showLineNumber?: boolean;
  startLine?: number;
  endLine?: number;
  branch?: string;
}) {
  const [code, setCode] = useState(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    getCode(user, repo, filePath, branch)
      .then((code) => {
        setCode(code);
        setLoading(false);
      })
      .catch((error) => {
        setError(error);
        setLoading(false);
      });
  }, []);

  if (loading) return <div>Chargement...</div>;

  if (error)
    return <div>Une erreur est survenue. Appellez votre enseignant!</div>;

  const lines = code.split("\n");
  const slicedLines = lines.slice(startLine < 1 ? 0 : startLine - 1, endLine);
  const linesToDisplay = slicedLines.join("\n");

  if (language == null) {
    language = filePath.split(".").at(-1);
  }

  return (
    <CodeBlock showLineNumbers={showLineNumber} language={language}>
      {linesToDisplay}
    </CodeBlock>
  );
}

async function getCode(
  user: string,
  repo: string,
  filePath: string,
  branch: string
): Promise<string> {
  var request = new XMLHttpRequest();
  return new Promise(function (resolve, reject) {
    request.onreadystatechange = function () {
      if (request.readyState == 4) {
        if (request.status >= 300) {
          reject("Error, status code = " + request.status);
        } else {
          resolve(request.responseText);
        }
      }
    };
    request.open(
      "GET",
      `https://raw.githubusercontent.com/${user}/${repo}/${branch}/${filePath}`
    );
    request.send();
  });
}
