# Robô Tupiniquim

## Especificação

A Agência Espacial Brasileira (AEB) contratou a Academia do Programador para desenvolver o software de guia do **Robô Tupiniquim I**, que fará análises em Marte. O robô explorará uma área retangular dividida em um grid.

## Sobre o Sistema

### Posição e Orientação

A posição do robô é dada por coordenadas `(X, Y)` e uma letra que representa a direção para onde ele está olhando (Norte, Sul, Leste, Oeste).

### Comandos

A AEB envia strings de comando simples (`E`, `D`, `M`):

| Comando | Nome     | Ação                                                            |
| ------- | -------- | --------------------------------------------------------------- |
| `E`     | Esquerda | Vira o robô 90 graus, sem sair do lugar.                        |
| `D`     | Direita  | Vira o robô 90 graus, sem sair do lugar.                        |
| `M`     | Mover    | Move o robô uma posição no grid para frente, mantendo a direção. |

## Entrada

O programa receberá os comandos de exploração em duas partes:

1. **Posição inicial:** dois inteiros (`X` e `Y`) e uma letra (orientação), separados por espaços.
2. **Sequência de comandos:** uma série de instruções (`E`, `D`, `M`) que o robô deve seguir.

## Saída

Após mover o robô, o programa deve retornar sua posição final (`X Y`) e sua orientação.

## Exemplo

**Input:**

```text
Digite a posição inicial: 1 2 N
Digite a sequência de comandos: EMEMEMEMM
```

**Output esperado:**

```text
Posição alcançada: 1 3 N
```
