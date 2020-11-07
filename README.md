# Scaling Azure Functions on AKS with KEDA
Code to play and test with KEDA 2.0 and automatically scaling Azure Functions on AKS from 0 to n.

### What does this example do?
- Host an Azure Function in Azure Kubernetes Service
- Have a default of 0 deployments and scale to however many I would need to get the job done as fast as possible
- Use an Azure Function that picks up messages from an Azure Storage queue
Get the contents of the messages and store them as a txt file in Azure Storage blobs

### Required Components
- Azure Kubernetes Cluster
- KEDA 2.0 installed on the Kubernetes Cluster
- Azure Container Registry
- Azure Function to process the queue messages
- Dockerfile with the correct configuration and environment variables to build and run the function.
- Required secrets in AKS for the Pods parse when starting the container

Link to blog post and walkthrough: [here](https://www.wesleyhaakman.org/scaling-azure-functions-from-zero-to-n-hero-on-kubernetes-with-keda/)
