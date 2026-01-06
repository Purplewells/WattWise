# Assistant Interaction Guidelines

This document defines a concise template and example for instructing the repository assistant.

1. Goal

- Describe the desired outcome and acceptance criteria (what "done" looks like).

2. Context

- Provide repository path, relevant files (for example: `Controllers/HomeController.cs`), branch, and environment (OS, runtime).

3. Scope

- State which files or folders I may change and which must not be touched.

4. Inputs / Outputs

- Include sample inputs, expected outputs, or before/after file snippets when appropriate.

5. Constraints

- Language/framework versions, coding style, performance limits, or test requirements.

6. Actionable steps

- Specify whether to implement, run tests, format, commit, open a PR, etc.

7. Response format

- Say how you want results delivered (`apply_patch` changes, code snippets, test output, checklist).

8. Ambiguity policy

- Tell the assistant whether to ask clarifying questions or make reasonable assumptions and proceed.

9. Priority / Deadline

- Indicate urgency or which parts to prioritize if partial work is acceptable.

Example instruction

- "Implement API endpoint `/api/meters` returning latest meter readings as JSON; add unit tests; update `Controllers/MetersController.cs`; run tests; commit to `feature/meters-api`."

Placement recommendation

- Keep this file in the repository so instructions travel with the code. Suggested locations: `.github/assistant_instructions.md` (this file), `DEVELOPER_GUIDE.md`, or `docs/`.

Notes

- You may paste one-off instructions in chat for immediate work. Persisted files are recommended for repeatable, team-wide behavior.
