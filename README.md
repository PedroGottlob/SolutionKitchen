✅ Passo a passo:
Pare e remova o container antigo (se quiser):
docker rm -f meu-container

(Opcional) Remova a imagem antiga:
docker rmi minha-imagem

Build com o novo nome:
docker build -t solution-kitchen .

Rode com o novo nome da imagem:
docker run -d -p 8080:80 --name meu-container solution-kitchen


🔍 Verifique:

docker images

Você verá:
REPOSITORY         TAG       IMAGE ID       CREATED         SIZE
solution-kitchen   latest    abc123...      X seconds ago   XXXMB


