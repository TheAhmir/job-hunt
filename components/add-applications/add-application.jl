using Pkg
Pkg.activate("..\\..\\julia-env/")
using DataFrames, CSV, Dates

function addApplication(data)
    println("Filling a new job application...\n")
    print("Enter type of position: ")
    type = readline()
    print("Enter company name: ")
    company = readline()
    print("Enter position: ")
    position = readline()
    print("Enter link: ")
    link = readline()

    status = ""
    while true
        print("Did you apply? (y/n): ")
        response = readline()
        if lowercase(response) in ["yes", "y"]
            status = "Applied"
            break
        elseif lowercase(response) in ["no", "n"]
            status = "Not Applied"
            break
        else
            println("Please enter 'yes' or 'no'.")
        end
    end

    print("Any notes? ")
    notes = readline()

    # Create a new row and append it to the DataFrame
    new_row = DataFrame(Type = type, Company = company, Position = position, Link = link, Date_added = now(), Status = status, Notes = notes)
    append!(data, new_row; promote=true)

    # Write the updated DataFrame back to the CSV file
    CSV.write("..\\job-applications.csv", data)

    println("\n1 new application has been added!")
    println("Don't stop here, apply for more!\n\n")
end

# Read the CSV file into a DataFrame
data = CSV.read("..\\job-applications.csv", DataFrame; missingstring="")

while true
    addApplication(data)
end
