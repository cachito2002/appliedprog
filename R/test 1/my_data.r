# setwd("/Users/fernandoferraez/Desktop/appliedprog/R/test 1/")

# --> my file is recognized as "data"

library(tidyverse)

data <- read.csv("friends.csv")
#------THIS PART CLEANS UP GENDER COLUMNS TO BE MORE READABLE AND MORE MANAGEABLE------
data <- data %>%
mutate(
    friends_gender = str_to_upper(gender),

    friends_gender = case_when(
        friends_gender == "M" ~ "MALE",
        friends_gender == "F" ~ "FEMALE",
        TRUE ~ friends_gender
    )
)
# print(data$friends_gender) 

#-------CODE FOR PEOPLE WITH OUT GENDERS--------








