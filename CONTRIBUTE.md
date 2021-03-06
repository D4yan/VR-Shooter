# Contribution Guide
## Getting started
- Install git (https://git-scm.com/download)
- Clone the git repo (user credentials needed from ops.hs-kemtpen.de)
```sh
git clone https://ops.hs-kempten.de/ChristophBichlmeier/2021-gelab-vr-shooter-bichlmeier.git
```
- change directory
```sh
cd 2021-gelab-vr-shooter-bichlmeier
```
- set name and email appearing on commits
```sh
git config user.name "John Doe"
git config user.email "JohnDoe@stud.hs-kempten.de"
```

## Implement feature or fix
- Change branch to develop
```sh
git fetch origin develop
git pull origin develop
git checkout develop
```
- Create new branch to work on
```sh
git branch feature-short-descriptive-name
git checkout feature-short-descriptive-name
```
## Commit changes
- Check for modified files
```sh
git status
```
- Check in files to be commited

IMPORTANT! check if there are .meta files listed. Commit them always alongside NEWLY created Files and Folders NOT BY THEMSELF
```sh
git add PATH PATH2
```
- Commit checked in files (Short description of what you did. Ex. "Fixed Head Rotation in Player prefab" or "Shortend Fingers in Player Hand Model" NOT "Fixed an issue" or "Updated file")
```sh
git commit
```
- Push your NEW branch to gitlab
```sh
git push --set-upstream origin your-branch-name
```
- Push your branch to gitlab
```sh
git push
```
## Folder Structure
- Please check your own work and the merge requests of others if the following structure is kept
```
+---GameAssets
¦   +---Enemies
¦   ¦   +---EnemyOne
¦   ¦   ¦   +---Materials
¦   ¦   ¦  	    +---Images
¦   ¦   ¦   +---Models
¦   ¦   ¦   +---Scripts
¦   ¦   ¦   +---Sounds
¦   ¦   +---EnemyTwo
¦   ¦       +---Materials
¦   ¦      	    +---Images
¦   ¦       +---Models
¦   ¦       +---Scripts
¦   ¦       +---Sounds
¦   ¦   +---Scripts
¦   +---Level
¦   ¦   +---Materials
¦   ¦       +---Images
¦   ¦   +---Models
¦   ¦   +---Scripts
¦   ¦   +---Sounds
¦   +---PlayerPC
¦   +---PlayerVR
¦       +---Materials
¦   	    +---Images
¦       +---Models
¦       +---Scripts
¦       +---Sounds
+---Plugins
¦   +---Cyberith
¦   +---SteamVR
¦   +---SteamVR-Resources
¦   +---XR
+---Scenes
+---StreamingAssets
```
## Create a Merge request
- Goto [merge requests](https://ops.hs-kempten.de/ChristophBichlmeier/2021-gelab-vr-shooter-bichlmeier/-/merge_requests) and create a new request.
- If you want someone to look over your changes add them to the reviewers. They will get notified by gitlab.

## Update the current local branch
```sh
git fetch
git pull
```

