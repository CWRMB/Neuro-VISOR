# virtual-reality
Repository for Temple University's Center for Computational Mathematics and Modeling's virtual reality project

## Cloning this repository
Git users (versions < 2.23.0) should clone the repository by using
`git lfs clone` all other should use `git clone`.

For users of older git versions this remedies the problem that every LFS versioned file will ask the user for their password.

## Requirements before contributing
- Unity 2019.1.0f2

- Git version >= 2.7.0

- Git LFS version >= 2.10.0

*Note*: A git pre-commit hook will ensure version consistency.
The user should install the hooks by calling `./install_git_hooks.sh` after clone from the root directory.

### Make sure appropriate versions are used
Pre-commit hook will block commits made with inappropriate versions of git LFS or Unity
- git lfs: `git lfs env` in a terminal/console.
- git: `git --version`
- Unity: see UnityEditor

