---
name: pr-commit
description: Create a git commit with staged or specified changes
---

# Commit Changes Skill

This skill handles creating a well-formatted git commit.

## Instructions

Follow these steps to create a commit:

1. **Check current state** (run in parallel):
   - `git status` — see untracked and modified files (never use -uall flag)
   - `git diff` — see unstaged changes
   - `git diff --staged` — see already staged changes
   - `git log -5 --oneline` — check recent commit message style

2. **Stage files**:
   - If nothing is staged yet, ask user which files to add
   - Stage specific files: `git add <file1> <file2>...`
   - **Never** stage sensitive files (.env, credentials.json, etc.)
   - Prefer specific files over `git add .` or `git add -A`

3. **Draft commit message**:
   - Analyze all staged changes (both previously staged and newly added)
   - Determine the nature: new feature, enhancement, bug fix, refactor, docs, etc.
   - Write a concise (1-2 sentence) message focusing on "why" not "what"
   - Match the repository's existing commit style
   - Ensure accuracy — "add" means wholly new, "update" means enhancement, "fix" means bug fix

4. **Create commit**:
   - Use HEREDOC format for proper message formatting:
     ```bash
     git commit -m "$(cat <<'EOF'
     Your commit message here.
     
     Co-Authored-By: Claude Sonnet 4.5 <noreply@anthropic.com>
     EOF
     )"
     ```
   - Run `git status` after to verify success

5. **Handle pre-commit hook failures**:
   - If hooks fail, the commit did NOT happen
   - Fix the issue identified by the hook
   - Re-stage fixed files
   - Create a **NEW** commit (never use --amend unless explicitly requested)
   - **CRITICAL**: Never skip hooks with --no-verify

## Safety Rules

- **NEVER** commit without explicit user request
- **NEVER** use --no-verify or --no-gpg-sign
- **NEVER** amend commits unless user explicitly asks
- **NEVER** create empty commits
- Do not push to remote (that's a separate action)
- Warn if sensitive files are being committed

## Example Commit Messages

Good:
- "Add student phone validation to prevent invalid formats"
- "Fix Edit action losing student data on concurrent updates"
- "Update Student model to support nullable email field"

Bad:
- "changes" / "updates" / "fix" (too vague)
- "Added code to validate phone number and also fixed a bug in the edit controller and updated the model" (too long, multiple concerns)
