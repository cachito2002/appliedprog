#================================================================================
# Sets the directory to the current one so the code can run
# (LINE 5)
#================================================================================
setwd("C:/Users/cachi/OneDrive - BYU-Idaho/appliedprog/R/test 1")
# --> my file is recognized as "data"

#================================================================================
# this is using the tidyverse library
# (LINE 12)
#================================================================================
library(tidyverse)

#================================================================================
# this reads the csv
# (LINE 18)
#================================================================================
data <- read.csv("friends.csv")

#================================================================================
#Reads through code to change all individual letters to a whole Word
#(LINES 14-22)
#================================================================================
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

#================================================================================
#This piece of code searches for missing FEMALE or MALE 
# (LINES 26-30)
#===============================================================================
data <- data %>%
    mutate(
        friends_gender = case_when(
            friends_gender != "MALE" & friends_gender != "FEMALE" ~ "N/A",
            TRUE ~ friends_gender
        )
)
#=============================================================================
#Function used to convert lbs to kg
#The factor that is being used is 0.45359237
# (Lines 38-40)
#=============================================================================
pounds_to_kg <- function(weight_lbs) {
    friend_kg_conversion <- weight_lbs * 0.45359237
    return(round(friend_kg_conversion, 2))
}
#=============================================================================
#Creates variable friends__kg_conversion to the function up above 
# (LINES 40-43)
#=============================================================================
data <- data %>%
    mutate(
        friends__kg_conversion = pounds_to_kg(weight_lbs)
    )
#=============================================================================
#Function of weight putting them into category from Light - Heavy 
# (LINES 48-65)
#=============================================================================

categorize_weight <- function(kg_column){

weight_categories <- c()
    for (weight in kg_column){

        if (is.na(weight))
        category <- "MISSING"
        else if (weight < 50) {
            category <- "LIGHT"
        }else if (weight >= 50 && weight < 90){
            category <- "MEDIUM"
        }else{
            category <- "HEAVY"
    }
    weight_categories <- append(weight_categories,category)

    }
    return(weight_categories)
}
#=============================================================================
#THIS ASSIGNS THE WEIGHT CATEGORIZE_WEIGHT TO WEIGHT_CATEGORY
# (LINES 82-84)
#=============================================================================
data <- data %>%
    mutate(
        weight_category = categorize_weight(friends__kg_conversion)
    )
#=============================================================================
#THIS PRINTS ALL THE NEW COLUMNS THAT WERE MADE PREVIOUS
#(LINES 90-94)
#=============================================================================
data %>%
    arrange(name) %>%
    select(name, friends_gender,friends__kg_conversion, weight_category) %>%
    print()
#=============================================================================
#THIS IS THE WHOLE PIECE OF CODE
#MODIFIES THE CODE TO READ AND WRITE NEW CODE WITH THE REQUIRED ADJUSTMENTS
#=============================================================================






