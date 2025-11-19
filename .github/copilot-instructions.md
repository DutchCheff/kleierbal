<!-- .github/copilot-instructions.md for kleierbal prototype -->
# Copilot instructions — kleierbal (prototype)

Purpose: give an AI coding agent the minimal, practical knowledge to be productive in this repository.

- **Big picture**: this repository contains a small static web prototype under `prototype/` that uses Tailwind CSS (via the Tailwind CLI) to generate compiled CSS. There is no backend or build system beyond the Tailwind CLI. Key files:
  - `prototype/index.html` — main prototype HTML
  - `prototype/package.json` — dependency and script definitions (see `scripts.watch`)
  - `prototype/src/input.css` — Tailwind entry (imports Tailwind)
  - `prototype/src/style.css` — compiled output produced by the CLI
  - `README.md` — minimal; no extra instructions present

- **How to run / common developer commands** (run from `Deepdive-2/kleierbal/prototype`):
  - Install dependencies: `npm install`
  - Rebuild CSS once: `npx tailwindcss -i ./src/input.css -o ./src/style.css`
  - Run continuous compile (dev): `npm run watch` — this runs `npx @tailwindcss/cli -i ./src/input.css -o ./src/style.css --watch` as defined in `package.json`.
  - Serve the static files for manual testing: `python -m http.server 8000` or `npx http-server .` (run in the `prototype/` folder and open `http://localhost:8000`)

- **Code patterns & conventions specific to this repo**
  - CSS workflow: you edit `prototype/src/input.css` (it contains `@import "tailwindcss"`), then run the Tailwind CLI to generate `prototype/src/style.css`. The HTML should link to `src/style.css`.
  - Static-first: there is no JS framework; changes will be in HTML and CSS in `prototype/`.
  - Keep prototype assets inside `prototype/` — do not move compiled outputs into the repo root.

- **Where to look for context when asked to modify visuals or layout**
  - Start at `prototype/index.html` and confirm it references `src/style.css` (if it doesn't, add a `<link rel="stylesheet" href="src/style.css">`).
  - Edit `prototype/src/input.css` to add Tailwind layers or utility includes; then run the watch script to see changes.

- **Testing & CI**
  - There are no tests or CI configs in the repo. `package.json` contains only `watch` and a placeholder `test` script. Do not add assumptions about existing test runners.

- **Editing / PR guidance for the AI**
  - Make minimal, focused edits. If you change CSS generation (e.g., switch to a different output path), update `package.json` `scripts.watch` accordingly and document the change in this file or `README.md`.
  - When adding new files, place them under `prototype/` unless they are global assets needed across other subfolders.
  - Prefer to modify `prototype/src/input.css` rather than editing generated `prototype/src/style.css` directly.

- **Examples**
  - Add a new utility class: edit `prototype/src/input.css`, save, ensure `npm run watch` is running to produce updated `prototype/src/style.css`, then verify in `prototype/index.html` (open in browser).
  - If asked to wire a dev server, prefer lightweight tools (`python -m http.server`, `npx http-server`) rather than adding a bundler.

If any of the above is incorrect or you want different conventions (different dev server, build directory, or an opinionated CI), tell me where and I will update this file.  

-- End
