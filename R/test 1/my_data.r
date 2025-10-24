# setwd("/Users/fernandoferraez/Desktop/appliedprog/R/test 1/")
data <- read.csv("friends.csv")

library(tidyverse)

under_25 <- data %>%
  filter(age < 25)

print(under_25)

