LocationVoiture

Projet de gestion de location de voitures réalisé avec ASP.NET Core 8 MVC.

Le projet utilise Docker pour la conteneurisation, GitHub Actions pour l'intégration continue et Kubernetes pour le déploiement.

Technologies

- ASP.NET Core 8 MVC
- Entity Framework Core
- SQLite
- Docker
- Docker Hub
- Kubernetes
- GitHub Actions


Lancer le projet en local

Avec .NET

Restaurer les packages :

`bash
dotnet restore

Lancer l'application :

`bash
dotnet run


 Docker

Création de l'image :

bash
docker build -t thanuweb/locationvoiture:latest .


Lancer le conteneur :

bash
docker run -p 8080:8080 thanuweb/locationvoiture:latest


L'application est accessible sur :


http://localhost:8080




## GitHub Actions

Le workflow permet de :

- compiler l'application ASP.NET Core
- créer l'image Docker
- envoyer l'image vers Docker Hub

Le workflow se lance automatiquement lors d'un push sur `main` ou d'une Pull Request.



## Kubernetes

Les fichiers Kubernetes sont dans le dossier :


kubernetes/


Ils permettent de créer :

- un Deployment pour l'application
- un Service pour accéder à l'application
- un stockage persistant pour la base SQLite



## Déploiement Kubernetes

Appliquer les fichiers :

bash
kubectl apply -f kubernetes/


Voir les pods :

bash
kubectl get pods
```

Voir les services :

bash
kubectl get services


L'application est accessible avec le port NodePort indiqué par le service.

Exemple :

http://localhost:30892

 Docker Hub

Image disponible :
thanuweb/locationvoiture:latest

Structure du projet


LocationVoiture
│
├── Controllers
├── Models
├── Data
├── Services
├── Views
│
├── Dockerfile
├── kubernetes
│   ├── deployment.yaml
│   ├── service.yaml
│   └── persistent-volume.yaml
│
└── .github/workflows
    └── docker-build.yml
