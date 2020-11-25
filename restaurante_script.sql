Drop database if exists db_restaurante;

-- Banco de dados
create database db_restaurante
default character set utf8
default collate utf8_general_ci;

use db_restaurante;

-- Usuario de banco de dados

create user 'restaurante'@'localhost' identified with mysql_native_password by '123456';
grant all privileges on db_restaurante.* to 'restaurante'@'localhost';

-- Tabelas

create table Cargo(
	id int primary key auto_increment,
    nome varchar(30) not null,
    descricao mediumtext,
    valor decimal(6,2) not null
);

create table Funcionario(
	id int primary key auto_increment,
    nome varchar(30) not null,
    cpf varchar(15) not null,
    dataNascimento date not null,
    sexo varchar(20),
    idCargo int not null,
    constraint fk_cargo foreign key (idCargo) references Cargo(id)
);

create table Categoria(
	id int primary key auto_increment,
    nome varchar(30) not null
);

create table Produto(
	id int primary key auto_increment,
    nome varchar(50) not null,
    idCategoria int not null,
    capa varchar(200),
    valor decimal(6,2) not null,
    info mediumtext,
    validade date not null,
    quantidade int not null,
    promocao enum ('S','N'),
	constraint fk_categoria foreign key (idCategoria) references Categoria(id)
);


create table Telefone(
	id int primary key auto_increment,
    ddd int,
    numero int
);

create table Celular(
	id int primary key auto_increment,
    ddd int not null,
    numero int not null
);

create table Cliente(
	id int primary key auto_increment,
    cpf varchar(15) not null,
    nome varchar(30) not null ,
    idCelular int,
    idTelefone int,
    constraint fk_celular foreign key (idCelular) references Celular(id),
    constraint fk_telefone foreign key (idTelefone) references Telefone(id)
);

create table Venda(
	id int primary key auto_increment,
    idCliente int not null,
    idFuncionario int not null,
	statusPagamento varchar(40),
	dataEmissao date not null,
    total decimal(6,2) not null,
    porcentagemDesconto int,
    vezesParcelamento int,
	constraint fk_cliente foreign key (idCliente) references Cliente(id),
    constraint fk_funcionario foreign key (idFuncionario) references Funcionario(id)
);

create table Itens(
	idVenda int not null,
    idProduto int not null,
    quantidade int not null,
	constraint fk_venda foreign key (idVenda) references Venda(id),
    constraint fk_produto foreign key (idProduto) references Produto(id)
);

create table Mesa(
	id int primary key
);

create table VendaLocal(
	id int primary key auto_increment,
    idVenda int not null,
    idMesa int not null,
	constraint fk_id_venda foreign key (idVenda) references Venda(id),
    constraint fk_mesa foreign key (idMesa) references Mesa(id)
);

create table Delivery(
	id int primary key auto_increment,
    idVenda int not null,
    Endereco int not null,
	constraint fk_venda_delivery foreign key (idVenda) references Venda(id)
);

create table Reserva(
    id int primary key auto_increment,
    idMesa int not null,
    quantidadeCadeiras int not null,
    dataReserva date not null,
    hora varchar(15) not null,
    idCliente int not null,
	constraint fk_cliente_reserva foreign key (idCliente) references Cliente(id),
    constraint fk_mesa_reserva foreign key (idMesa) references Mesa(id)
);

create table Relatorio(
    id int primary key auto_increment,
    dataRelatorio date,
	autor varchar(50) not null,
    departamento varchar(30) not null,
    titulo varchar(90) not null,
    corpo longtext not null
);

-- Alterações

alter table Categoria
rename column nome to categoria;

alter table Cliente
rename column nome to cliente;

alter table Funcionario
rename column nome to funcionario;

alter table Produto
rename column nome to produto;

alter table Cargo
rename column nome to cargo;

-- Views

create view viewProduto
as select
	Produto.id,
    Produto.produto,
    Categoria.categoria,
    Produto.capa,
	Produto.valor,
    Produto.info,
    Produto.validade,
    Produto.quantidade,
    Produto.promocao
from Produto inner join Categoria
	on produto.idCategoria = categoria.id;
    
create view viewFuncionario
as select
	Funcionario.id,
	Funcionario.funcionario,
    Cargo.cargo,
    Funcionario.cpf,
	Funcionario.dataNascimento
from Funcionario inner join Cargo
	on Funcionario.idCargo = Cargo.id;
    
create view viewPedido
as select
	Venda.id,
	Cliente.cliente,
    Funcionario.funcionario,
    Produto.produto,
    Produto.valor,
    Itens.quantidade,
    Venda.porcentagemDesconto,
	Venda.total,
    Venda.statusPagamento,
    Venda.dataEmissao
from Venda inner join Cliente
	on Venda.idCliente = Cliente.id
inner join Itens
	on Venda.id = Itens.idVenda
inner join Funcionario
	on Funcionario.id = Venda.idFuncionario
inner join Produto
	on Itens.idProduto = Produto.id;

create view viewPedidoDelivery
as select
	Cliente.cliente,
    Delivery.endereco,
    Produto.produto,
    Produto.valor,
    Venda.porcentagemDesconto,
	Venda.total,
    Venda.dataEmissao
from Venda inner join Cliente
	on Venda.idCliente = Cliente.id
inner join Itens
	on Venda.id = Itens.idVenda
inner join Delivery
	on Delivery.idVenda = Venda.id
inner join Produto
	on Itens.idProduto = Produto.id;
    
-- Selects

select * from cargo;
select * from categoria;
select * from celular;
select * from cliente;
select * from delivery;
select * from funcionario;
select * from itens;
select * from mesa;
select * from produto;
select * from relatorio;
select * from reserva;
select * from telefone;
select * from venda;
select * from vendalocal;

-- Inserts

Insert into cargo(id, nome, descricao, valor)
values(default, 'Garçom', 'O garçom é responsável por fazer o atendimento aos clientes, fornecendo informações sobre cardápio, anotando os pedidos e servindo as mesas.', 1514.00),
	(default, 'Maitre', 'O maitre é o anfitrião do restaurante. Responsável por agendar reservas e acomodar clientes.', 2069.00),
	(default, 'Caixa', 'Essa função administrativa é responsável por pagamentos, recebimento de valores, fechamento de caixa e emissão de notas fiscais.', 1271.99),
	(default, 'Chefe de Cozinha', 'Profissional responsável por organizar a cozinha e elaborar cardápios.', 2464.00),
	(default, 'Cozinheiro', 'Os cozinheiros são os responsáveis pelo preparo dos pratos, seguindo as orientações dos chefes de cozinha.', 1650.00),
	(default, 'Auxiliar de Cozinha', 'Este é o profissional responsável pelo pré-preparo, higienização, organização e pequenas produções de alimentos dos vários setores de um restaurante.', 1420.00),
	(default, 'Confeiteiro', 'O confeiteiro é o responsável por fazer as sobremesas servidas no restaurante.', 1420.00),
	(default, 'Bartender', 'O bartender é responsável por preparar coquetéis e bebidas.', 1559.00),
	(default, 'Gerente', 'Responsável por coordenar todo o time de funcionários e assim manter o desempenho, padrões de qualidade, saúde e segurança do local.', 2071.64),
	(default, 'Faxineiro', 'Profissional responsável pela higienização do restaurante.', 1381.00);

Insert into categoria(id, categoria)
values(default, 'Entradas'),
	(default, 'Pratos'),
	(default, 'Sobremesas'),
	(default, 'Bebidas');

Insert into mesa(id)
values(1),(2),(3),(4),(5),(7),(8),(9),(10),(11),(12),(13),(14),(15),(17),(18),(19),(20);

-- Simulando uma venda

insert into Funcionario(id, nome, cpf, dataNascimento, sexo, idCargo)
values(default, 'Augusto', '364.662.200-87', '1988-01-13', 'M', 2),
	(default, 'Margerito', '670.693.793-23', '1985-03-06', 'M', 9);
    
insert into Produto(id, nome, idCategoria, capa, valor, info, validade, quantidade, promocao)
values(default, 'Tortillas', '1', 'Tortillas.png', 23.00, 'Deliciosas tortillas com queijo.', '2020-11-29', 5, 'S'),
      (default, 'Palleta Mexicana sabor morango', '3', 'Palleta.png', 18.00, ' Sobremesa irresistível com recheio cremoso.', '2020-12-25', 10, 'N');

insert into Celular(id, ddd, numero)
values(default, 11, 984013009);

insert into Cliente(id, cpf, cliente, idCelular, idTelefone)
values(default, '853.371.537-49', 'Heloisa Monteiro', 1, null);

insert into Venda(id, idCliente, idFuncionario, statusPagamento, dataEmissao, total, porcentagemDesconto, vezesParcelamento)
values (default, 1, 1, 'Aguardando pagamento', '2020-11-23', 0.00, 0, 0);

insert into Itens(idVenda, idProduto, quantidade)
values(1, 1, 3),
      (1, 2, 4);
      
/* No sistema asp, deve-se atualizar o valor total de acordo com os produtos do pedido.
Nesse caso :
				23 x 3 = 69  (da Tortilla)
				18 x 4 = 72  (da Paleta Mexicana)
							
				total 141  (Não há desconto nenhum)
*/

update Venda
set total = 141.00
where id = 1;

-- Agora, um select na view para visualizar a venda por completo

select * from viewPedido;

-- Outras Views

select * from viewProduto;
select * from viewFuncionario;
select * from viewPedidoDelivery;

-- Select normal

select * from cargo;